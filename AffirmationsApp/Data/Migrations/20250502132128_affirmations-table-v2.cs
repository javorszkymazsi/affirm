using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AffirmationsApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class affirmationstablev2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Affirmation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "Affirmation");
        }
    }
}
