using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace STIMario.Migrations
{
    public partial class STIMario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ejercicios",
                columns: table => new
                {
                    IDejercicio = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreEjercicio = table.Column<string>(nullable: true),
                    puntaje = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ejercicios", x => x.IDejercicio);
                });

            migrationBuilder.CreateTable(
                name: "resultados",
                columns: table => new
                {
                    IDresultados = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    respuestasCorrectas = table.Column<int>(nullable: false),
                    respuestasIncorrectas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resultados", x => x.IDresultados);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ejercicios");

            migrationBuilder.DropTable(
                name: "resultados");
        }
    }
}
