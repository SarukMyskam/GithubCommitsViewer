using System.Drawing;
using Colorful;
using CommandLine;
using GithubCommitsViewer.Application;
using GithubCommitsViewer.Console.Commands;
using Microsoft.Extensions.DependencyInjection;
using Console = Colorful.Console;

var figlet = new Figlet();

Console.WriteLine(figlet.ToAscii("Github"), ColorTranslator.FromHtml("#8AFFEF"));
Console.WriteLine(figlet.ToAscii("commits"), ColorTranslator.FromHtml("#FAD6FF"));
Console.WriteLine(figlet.ToAscii("viewer."), ColorTranslator.FromHtml("#B8DBFF"));

var services = new ServiceCollection();
services.AddInfrastructure();

var serviceProvider = services.BuildServiceProvider();
serviceProvider.InitMigrations();

await Parser.Default.ParseArguments<PullCommitsCommand>(args)
    .WithParsedAsync(t => t.PassServiceProvider(serviceProvider).Execute());