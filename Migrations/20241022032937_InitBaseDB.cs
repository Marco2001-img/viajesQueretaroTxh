using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_Lozgar.Migrations
{
    /// <inheritdoc />
    public partial class InitBaseDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id_Cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_pasajero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono_pasajero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    diaViaje = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroPasajeros = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id_Cliente);
                });

            migrationBuilder.CreateTable(
                name: "Conductor",
                columns: table => new
                {
                    id_conductor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_conductor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conductor", x => x.id_conductor);
                });

            migrationBuilder.CreateTable(
                name: "ViajesDisponible",
                columns: table => new
                {
                    id_ViajeDisponible = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    origen_cuidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    destino_cuidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precio = table.Column<int>(type: "int", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoraSalida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoraLlegada = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViajesDisponible", x => x.id_ViajeDisponible);
                });

            migrationBuilder.CreateTable(
                name: "ViajeClientes",
                columns: table => new
                {
                    Id_ViajeClientes = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Cliente = table.Column<int>(type: "int", nullable: false),
                    id_conductor = table.Column<int>(type: "int", nullable: false),
                    id_ViajeDisponible = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViajeClientes", x => x.Id_ViajeClientes);
                    table.ForeignKey(
                        name: "FK_ViajeClientes_Cliente_Id_Cliente",
                        column: x => x.Id_Cliente,
                        principalTable: "Cliente",
                        principalColumn: "Id_Cliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ViajeClientes_Conductor_id_conductor",
                        column: x => x.id_conductor,
                        principalTable: "Conductor",
                        principalColumn: "id_conductor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ViajeClientes_ViajesDisponible_id_ViajeDisponible",
                        column: x => x.id_ViajeDisponible,
                        principalTable: "ViajesDisponible",
                        principalColumn: "id_ViajeDisponible",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ViajeClientes_Id_Cliente",
                table: "ViajeClientes",
                column: "Id_Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_ViajeClientes_id_conductor",
                table: "ViajeClientes",
                column: "id_conductor");

            migrationBuilder.CreateIndex(
                name: "IX_ViajeClientes_id_ViajeDisponible",
                table: "ViajeClientes",
                column: "id_ViajeDisponible");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ViajeClientes");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Conductor");

            migrationBuilder.DropTable(
                name: "ViajesDisponible");
        }
    }
}
