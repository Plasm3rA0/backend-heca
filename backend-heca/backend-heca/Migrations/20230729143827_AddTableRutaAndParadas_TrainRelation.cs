using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_heca.Migrations
{
    /// <inheritdoc />
    public partial class AddTableRutaAndParadas_TrainRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "rutaId",
                table: "Trains",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Ruta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ruta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parada",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RutaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parada_Ruta_RutaId",
                        column: x => x.RutaId,
                        principalTable: "Ruta",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trains_rutaId",
                table: "Trains",
                column: "rutaId");

            migrationBuilder.CreateIndex(
                name: "IX_Parada_RutaId",
                table: "Parada",
                column: "RutaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trains_Ruta_rutaId",
                table: "Trains",
                column: "rutaId",
                principalTable: "Ruta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trains_Ruta_rutaId",
                table: "Trains");

            migrationBuilder.DropTable(
                name: "Parada");

            migrationBuilder.DropTable(
                name: "Ruta");

            migrationBuilder.DropIndex(
                name: "IX_Trains_rutaId",
                table: "Trains");

            migrationBuilder.DropColumn(
                name: "rutaId",
                table: "Trains");
        }
    }
}
