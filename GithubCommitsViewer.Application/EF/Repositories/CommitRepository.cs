using System.Collections.Generic;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using GithubCommitsViewer.Application.Entities;

namespace GithubCommitsViewer.Application.EF.Repositories;

public class CommitRepository : ICommitRepository
{
    private readonly GithubCommitsViewerContext _dbContext;

    public CommitRepository(GithubCommitsViewerContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SaveCommits(IList<Commit> commits)
    {
        await _dbContext.BulkInsertOrUpdateAsync<Commit>(commits);
    }
}