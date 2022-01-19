using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GithubCommitsViewer.Application.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "githubcommitsviewer");

            migrationBuilder.CreateTable(
                name: "Commits",
                schema: "githubcommitsviewer",
                columns: table => new
                {
                    Sha = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RepositoryOwner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepositoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommitterName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commits", x => x.Sha);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commits",
                schema: "githubcommitsviewer");
        }
    }
}
