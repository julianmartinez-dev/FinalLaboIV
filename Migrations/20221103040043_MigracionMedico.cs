﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Turnos.Migrations
{
    public partial class MigracionMedico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    IdMedico = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Matricula = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Direccion = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Localidad = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    HorarioEntrada = table.Column<DateTime>(unicode: false, nullable: false),
                    HorarioSalida = table.Column<DateTime>(unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.IdMedico);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medico");
        }
    }
}
