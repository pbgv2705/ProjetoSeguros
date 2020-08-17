using Microsoft.EntityFrameworkCore.Migrations;

namespace data.Migrations
{
    public partial class NovoNomeCorretor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Corretores");

            migrationBuilder.AddColumn<string>(
                name: "NomeCorretor",
                table: "Corretores",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeCorretor",
                table: "Corretores");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Corretores",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
