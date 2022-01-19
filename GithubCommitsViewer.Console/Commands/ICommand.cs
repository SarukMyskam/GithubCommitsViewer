namespace GithubCommitsViewer.Console.Commands;

public interface ICommand
{
    ICommand PassServiceProvider(IServiceProvider serviceProvider);
    Task Execute();
}