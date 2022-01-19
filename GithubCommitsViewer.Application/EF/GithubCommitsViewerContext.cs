using GithubCommitsViewer.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace GithubCommitsViewer.Application.EF;

public class GithubCommitsViewerContext : DbContext
{
    public DbSet<Commit> Commits { get; set; }

    public GithubCommitsViewerContext(DbContextOptions<GithubCommitsViewerContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("githubcommitsviewer");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}