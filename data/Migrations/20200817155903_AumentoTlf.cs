using Microsoft.EntityFrameworkCore.Migrations;

namespace data.Migrations
{
    public partial class AumentoTlf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Telefone",
                table: "Clientes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Telefone",
                table: "Clientes",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
