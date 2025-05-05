using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AffirmationsApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AffirmationsMigrationAddLanguage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Affirmation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LanguageVariant",
                table: "Affirmation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "Affirmation");

            migrationBuilder.DropColumn(
                name: "LanguageVariant",
                table: "Affirmation");
        }
    }
}
