using System.ComponentModel.DataAnnotations;

namespace GithubCommitsViewer.Application.Entities;

public class Commit
{
    [Key]
    public string Sha { get; set; }
    public string RepositoryOwner { get; set; }
    public string RepositoryName { get; set; }
    public string Message { get; set; }
    public string CommitterName { get; set; }
}