using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AffirmationsApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AffirmationRemoveLanguageVariant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LanguageVariant",
                table: "Affirmation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LanguageVariant",
                table: "Affirmation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
