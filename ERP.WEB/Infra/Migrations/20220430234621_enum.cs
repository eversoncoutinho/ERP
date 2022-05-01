using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class @enum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Unidade",
                table: "Compras",
                newName: "Unidades");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Unidades",
                table: "Compras",
                newName: "Unidade");
        }
    }
}
