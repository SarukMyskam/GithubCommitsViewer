using CommandLine;
using GithubCommitsViewer.Application.Clients.Github;
using GithubCommitsViewer.Application.Clients.Github.Exceptions;
using GithubCommitsViewer.Application.EF.Repositories;
using GithubCommitsViewer.Application.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace GithubCommitsViewer.Console.Commands;

[Verb("pull", HelpText = "Get all selected user commits from repository")]
public class PullCommitsCommand : ICommand
{
    [Option('r', "repository", Required = true,
        HelpText = "Provide repository name, for which you want to download commits")]
    public string RepositoryName { get; set; }
    
    [Option('u', "user", Required = true, HelpText = "Provide for which user you want to download commits")]
    public string UserName { get; set; }
    
    private IServiceProvider _serviceProvider;
    
    //For reviewers: This is hack, to handle DI in fastest way with this command line lib. In real app, it should be done in different way, maybe with another CLI lib, or some own implementation
    public ICommand PassServiceProvider(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

        return this;
    }

    public async Task Execute()
    {
        if (_serviceProvider is null)
        {
            System.Console.WriteLine($"CLI app is broken :<");
        }
        
        var client = _serviceProvider.GetService<IGithubClient>();
        try
        {
            var commitRepository = _serviceProvider.GetService<ICommitRepository>();
            var commitsToSave = new List<Commit>();
            await foreach (var commit in client.PullCommits(RepositoryName, UserName))
            {
                commitsToSave.Add(new Commit()
                {
                    Sha = commit.Sha,
                    CommitterName = commit.CommitterName,
                    Message = commit.Message,
                    RepositoryOwner = UserName,
                    RepositoryName = RepositoryName,
                });
                if (commitsToSave.Count > 100)
                {
                    await commitRepository.SaveCommits(commitsToSave);
                    commitsToSave.Clear();
                }
                System.Console.WriteLine($"[{RepositoryName}]/[{commit.Sha}]: {commit.Message} [{commit.CommitterName}]");
            }
            
            if (commitsToSave.Count > 0)
            {
                await commitRepository.SaveCommits(commitsToSave);
            }
        }
        catch (RepositoryNotFoundException e)
        {
            System.Console.WriteLine($"Repository {UserName}/{RepositoryName} not found");
        }
    }
}