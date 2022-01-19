using System.Collections.Generic;
using System.Threading.Tasks;
using GithubCommitsViewer.Application.Entities;

namespace GithubCommitsViewer.Application.EF.Repositories;

public interface ICommitRepository
{
    public Task SaveCommits(IList<Commit> commits);
}