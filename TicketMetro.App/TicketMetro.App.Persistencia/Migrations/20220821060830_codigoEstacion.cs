using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketMetro.App.Persistencia.Migrations
{
    public partial class codigoEstacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cod_estacion",
                table: "Estaciones",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Estaciones_cod_estacion",
                table: "Estaciones",
                column: "cod_estacion",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Estaciones_cod_estacion",
                table: "Estaciones");

            migrationBuilder.DropColumn(
                name: "cod_estacion",
                table: "Estaciones");
        }
    }
}
