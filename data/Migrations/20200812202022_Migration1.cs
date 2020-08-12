using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace data.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Corretores",
                columns: table => new
                {
                    RMCreci = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_CorretorRMCreci", x => x.RMCreci);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Cpf = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(nullable: false),
                    NomeCliente = table.Column<string>(maxLength: 100, nullable: false),
                    Telefone = table.Column<int>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    Apolice = table.Column<int>(nullable: false),
                    Prime = table.Column<double>(nullable: false),
                    Cancelado = table.Column<bool>(nullable: false),
                    RMCreci = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_ClienteCpf", x => x.Cpf);
                    table.ForeignKey(
                        name: "FK_Clientes_Corretores_RMCreci",
                        column: x => x.RMCreci,
                        principalTable: "Corretores",
                        principalColumn: "RMCreci",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_RMCreci",
                table: "Clientes",
                column: "RMCreci");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Corretores");
        }
    }
}
