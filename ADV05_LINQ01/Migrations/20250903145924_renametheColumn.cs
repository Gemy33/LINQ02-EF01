using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADV05_LINQ01.Migrations
{
    /// <inheritdoc />
    public partial class renametheColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Courses",
                newName: "Curs_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Curs_id",
                table: "Courses",
                newName: "Id");
        }
    }
}
