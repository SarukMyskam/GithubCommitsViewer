using System.Collections.Generic;
using GithubCommitsViewer.Application.Clients.Github.Models;

namespace GithubCommitsViewer.Application.Clients.Github;

public interface IGithubClient
{
    public IAsyncEnumerable<Commit> PullCommits(string repository, string owner);
}