using System;
using GithubCommitsViewer.Application.Clients.Github;
using GithubCommitsViewer.Application.EF;
using GithubCommitsViewer.Application.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GithubCommitsViewer.Application;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services) =>
        services
            .AddScoped<IGithubClient, GithubClient>()
            .AddScoped<ICommitRepository, CommitRepository>()
            .AddDbContext<GithubCommitsViewerContext>(options => options.UseSqlServer("CONNECTION-STRING-PLACEHOLDER"));

    public static IServiceProvider InitMigrations(this IServiceProvider serviceProvider)
    {
        serviceProvider.GetService<GithubCommitsViewerContext>()?.Database.Migrate();

        return serviceProvider;
    }
}