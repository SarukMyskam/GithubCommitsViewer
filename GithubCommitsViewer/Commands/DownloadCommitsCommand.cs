using CommandLine;

namespace GithubCommitsViewer.Commands;

[Verb("pull", HelpText = "Save all selected user commits from repository")]
public class DownloadCommitsCommand : ICommand
{
    [Option('r', "repository", Required = true, HelpText = "Provide repository name, for which you want to download commits")]
    public string RepositoryName { get; set; }
    
    [Option('u', "user", Required = true, HelpText = "Provide for which user you want to download commits")]
    public string UserName { get; set; }
    
    public void Execute()
    {
        Console.WriteLine("Executing Push");
    }
}