using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_Lozgar.Migrations
{
    /// <inheritdoc />
    public partial class InitDBDos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boletos",
                columns: table => new
                {
                    ID_boletos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdViajesDisponible = table.Column<int>(type: "int", nullable: false),
                    OrigenCuidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinoCuidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DescripcionViaje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoraSalida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoraLlegada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPasajero = table.Column<int>(type: "int", nullable: false),
                    NombrePasajero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonoPasajero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaViaje = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boletos", x => x.ID_boletos);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boletos");
        }
    }
}
