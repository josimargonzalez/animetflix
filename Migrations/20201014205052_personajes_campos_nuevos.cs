using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace animetflix.Migrations
{
    public partial class personajes_campos_nuevos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Biografia",
                table: "Personajes",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Personajes",
                maxLength: 500,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Personajes",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Biografia",
                table: "Personajes");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "Personajes");

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Personajes");
        }
    }
}
