using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsumoDeLamina.Data.Migrations
{
    public partial class addUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConsumoDeLamina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProyecto = table.Column<int>(type: "int", nullable: false),
                    FechaInicial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notas = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumoDeLamina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConsumoDeLaminaDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad10 = table.Column<double>(type: "float", nullable: false),
                    Peso10 = table.Column<double>(type: "float", nullable: false),
                    Cantidad14 = table.Column<double>(type: "float", nullable: false),
                    Peso14 = table.Column<double>(type: "float", nullable: false),
                    Cantidad16 = table.Column<double>(type: "float", nullable: false),
                    Peso16 = table.Column<double>(type: "float", nullable: false),
                    Cantidad18 = table.Column<double>(type: "float", nullable: false),
                    Peso18 = table.Column<double>(type: "float", nullable: false),
                    Cantidad20 = table.Column<double>(type: "float", nullable: false),
                    Peso20 = table.Column<double>(type: "float", nullable: false),
                    Cantidad22 = table.Column<double>(type: "float", nullable: false),
                    Peso22 = table.Column<double>(type: "float", nullable: false),
                    Cantidad24 = table.Column<double>(type: "float", nullable: false),
                    Peso24 = table.Column<double>(type: "float", nullable: false),
                    Cantidad26 = table.Column<double>(type: "float", nullable: false),
                    Peso26 = table.Column<double>(type: "float", nullable: false),
                    PesoSR26 = table.Column<double>(type: "float", nullable: false),
                    PesoSR28 = table.Column<double>(type: "float", nullable: false),
                    PesoLiso18 = table.Column<double>(type: "float", nullable: false),
                    PesoLiso20 = table.Column<double>(type: "float", nullable: false),
                    PesoLiso22 = table.Column<double>(type: "float", nullable: false),
                    PesoLiso24 = table.Column<double>(type: "float", nullable: false),
                    PesoLiso26 = table.Column<double>(type: "float", nullable: false),
                    PesoLiso28 = table.Column<double>(type: "float", nullable: false),
                    consumoDeLaminaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumoDeLaminaDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsumoDeLaminaDetalles_ConsumoDeLamina_consumoDeLaminaId",
                        column: x => x.consumoDeLaminaId,
                        principalTable: "ConsumoDeLamina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsumoDeLaminaDetalles_consumoDeLaminaId",
                table: "ConsumoDeLaminaDetalles",
                column: "consumoDeLaminaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsumoDeLaminaDetalles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ConsumoDeLamina");
        }
    }
}
