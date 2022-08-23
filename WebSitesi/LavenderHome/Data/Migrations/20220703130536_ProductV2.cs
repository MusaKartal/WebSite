using Microsoft.EntityFrameworkCore.Migrations;

namespace LavenderHome.Data.Migrations
{
    public partial class ProductV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Products");
        }
    }
}
