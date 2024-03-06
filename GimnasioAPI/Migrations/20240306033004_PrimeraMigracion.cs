using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GimnasioAPI.Migrations
{
    /// <inheritdoc />
    public partial class PrimeraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Plan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Beneficios = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sucursales",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dirección = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoraDeApertura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraDeCierre = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursales", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioPlanes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    PlanesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioPlanes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UsuarioPlanes_Planes_PlanesID",
                        column: x => x.PlanesID,
                        principalTable: "Planes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioPlanes_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioSucursales",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    SucursalID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioSucursales", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UsuarioSucursales_Sucursales_SucursalID",
                        column: x => x.SucursalID,
                        principalTable: "Sucursales",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioSucursales_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Planes",
                columns: new[] { "ID", "Beneficios", "Plan", "Precio" },
                values: new object[,]
                {
                    { 1, "Puedes acceder a todas las maquinas, actividades del gimnasio", "Plan Premium", 39.990000000000002 },
                    { 2, "Tienes los beneficios del plan Premium, más CrossFit y acceso a todas las sucursales", "Plan Platino", 59.990000000000002 }
                });

            migrationBuilder.InsertData(
                table: "Sucursales",
                columns: new[] { "ID", "Dirección", "HoraDeApertura", "HoraDeCierre", "Nombre" },
                values: new object[,]
                {
                    { 1, "Centro de Guayaquil", new DateTime(2024, 3, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 5, 18, 0, 0, 0, DateTimeKind.Unspecified), "Sucursal Centro" },
                    { 2, "Centro Comercial el Dorado", new DateTime(2024, 3, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 5, 19, 0, 0, 0, DateTimeKind.Unspecified), "Sucursal Centro Comercial el Dorado" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "ID", "Apellido", "Cedula", "Direccion", "Nombre" },
                values: new object[,]
                {
                    { 1, "Pérez", "1234567890", "Juan Tan Ca Marengo", "Juan" },
                    { 2, "González", "0987654321", "Av. Francisco de Orellana", "María" }
                });

            migrationBuilder.InsertData(
                table: "UsuarioPlanes",
                columns: new[] { "ID", "PlanesID", "UsuarioID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "UsuarioSucursales",
                columns: new[] { "ID", "SucursalID", "UsuarioID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPlanes_PlanesID",
                table: "UsuarioPlanes",
                column: "PlanesID");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPlanes_UsuarioID",
                table: "UsuarioPlanes",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioSucursales_SucursalID",
                table: "UsuarioSucursales",
                column: "SucursalID");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioSucursales_UsuarioID",
                table: "UsuarioSucursales",
                column: "UsuarioID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioPlanes");

            migrationBuilder.DropTable(
                name: "UsuarioSucursales");

            migrationBuilder.DropTable(
                name: "Planes");

            migrationBuilder.DropTable(
                name: "Sucursales");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
