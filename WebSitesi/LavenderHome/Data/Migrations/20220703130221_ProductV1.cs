using Microsoft.EntityFrameworkCore.Migrations;

namespace LavenderHome.Data.Migrations
{
    public partial class ProductV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductRole_ProductRoleId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_productId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductRole");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductRoleId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_productId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductRoleId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "productId",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductRoleId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "productId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRole", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductRoleId",
                table: "Products",
                column: "ProductRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_productId",
                table: "Products",
                column: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductRole_ProductRoleId",
                table: "Products",
                column: "ProductRoleId",
                principalTable: "ProductRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Products_productId",
                table: "Products",
                column: "productId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
