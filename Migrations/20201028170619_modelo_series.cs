using Microsoft.EntityFrameworkCore.Migrations;

namespace animetflix.Migrations
{
    public partial class modelo_series : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Anio = table.Column<int>(nullable: false),
                    Sinopsis = table.Column<string>(maxLength: 500, nullable: true),
                    Trailer = table.Column<string>(nullable: true),
                    PosterUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Series");
        }
    }
}
