using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DadJokesAPI.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "punch",
                table: "Jokes",
                newName: "Punch");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Punch",
                table: "Jokes",
                newName: "punch");
        }
    }
}
