using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.WEB.Data.Migrations
{
    public partial class compras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            migrationBuilder.RenameTable(
                name: "Produtos",
                newName: "Compras");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Compras",
                table: "Compras",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Compras",
                table: "Compras");

            migrationBuilder.RenameTable(
                name: "Compras",
                newName: "Produtos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                column: "Id");
        }
    }
}
