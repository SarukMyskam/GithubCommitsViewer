using System.Collections.Generic;
using Octokit;
using Commit = GithubCommitsViewer.Application.Clients.Github.Models.Commit;

namespace GithubCommitsViewer.Application.Clients.Github;

public class GithubClient : IGithubClient
{
    private readonly GitHubClient _client;

    public GithubClient()
    {
        _client = new GitHubClient(new ProductHeaderValue("github-commits-viewer"));
    }

    public async IAsyncEnumerable<Commit> PullCommits(string repository, string owner)
    {
        IReadOnlyList<GitHubCommit> commits;
        try
        {
            commits = await _client.Repository.Commit.GetAll(owner, repository);
        }
        catch (NotFoundException e)
        {
            throw new Exceptions.RepositoryNotFoundException();
        }
        
        foreach (var commit in commits)
        {
            yield return new Commit
            {
                Sha = commit.Sha,
                Message = commit.Commit.Message,
                CommitterName = commit.Commit.Committer.Name
            };
        }
    }
}