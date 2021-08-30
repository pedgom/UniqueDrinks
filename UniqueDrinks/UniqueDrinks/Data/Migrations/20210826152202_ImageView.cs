using Microsoft.EntityFrameworkCore.Migrations;

namespace UniqueDrinks.Data.Migrations
{
    public partial class ImageView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Bebidas");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Clientes");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Bebidas",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
