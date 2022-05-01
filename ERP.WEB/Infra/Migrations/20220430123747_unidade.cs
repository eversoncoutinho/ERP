using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class unidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Unidade",
                table: "Compras",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unidade",
                table: "Compras");
        }
    }
}
