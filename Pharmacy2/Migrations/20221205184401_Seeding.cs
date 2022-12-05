using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharmacy2.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_drugs_categories_CategoryId",
                table: "drugs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_drugs",
                table: "drugs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categories",
                table: "categories");

            migrationBuilder.RenameTable(
                name: "drugs",
                newName: "Drugs");

            migrationBuilder.RenameTable(
                name: "categories",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_drugs_CategoryId",
                table: "Drugs",
                newName: "IX_Drugs_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drugs",
                table: "Drugs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Drugs_Categories_CategoryId",
                table: "Drugs",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drugs_Categories_CategoryId",
                table: "Drugs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Drugs",
                table: "Drugs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Drugs",
                newName: "drugs");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "categories");

            migrationBuilder.RenameIndex(
                name: "IX_Drugs_CategoryId",
                table: "drugs",
                newName: "IX_drugs_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_drugs",
                table: "drugs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categories",
                table: "categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_drugs_categories_CategoryId",
                table: "drugs",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
