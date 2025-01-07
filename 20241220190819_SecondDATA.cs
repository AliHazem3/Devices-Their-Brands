using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Device_and_Its_Brands.Migrations
{
    public partial class SecondDATA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Productx");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Categorx");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Productx",
                newName: "IX_Productx_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Productx",
                table: "Productx",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorx",
                table: "Categorx",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productx_Categorx_CategoryId",
                table: "Productx",
                column: "CategoryId",
                principalTable: "Categorx",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productx_Categorx_CategoryId",
                table: "Productx");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Productx",
                table: "Productx");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorx",
                table: "Categorx");

            migrationBuilder.RenameTable(
                name: "Productx",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Categorx",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_Productx_CategoryId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
