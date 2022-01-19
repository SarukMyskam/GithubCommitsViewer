using System.Drawing;
using Octokit;
using Console = Colorful.Console;
using Colorful;
using CommandLine;
using GithubCommitsViewer.Commands;

var figlet = new Figlet();

Console.WriteLine(figlet.ToAscii("Github"), ColorTranslator.FromHtml("#8AFFEF"));
Console.WriteLine(figlet.ToAscii("commits"), ColorTranslator.FromHtml("#FAD6FF"));
Console.WriteLine(figlet.ToAscii("viewer."), ColorTranslator.FromHtml("#B8DBFF"));

Parser.Default.ParseArguments<DownloadCommitsCommand>(args)
    .WithParsed(t => t.Execute());