using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day1.Migrations
{
    /// <inheritdoc />
    public partial class Removed_redunc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sale",
                table: "Instructors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sale",
                table: "Instructors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
