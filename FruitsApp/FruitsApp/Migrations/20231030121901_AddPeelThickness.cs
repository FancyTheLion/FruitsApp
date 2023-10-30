using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FruitsApp.Migrations
{
    /// <inheritdoc />
    public partial class AddPeelThickness : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PeelThickness",
                table: "Fruits",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeelThickness",
                table: "Fruits");
        }
    }
}
