using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estacionamiento_C.Migrations
{
    /// <inheritdoc />
    public partial class FixPersonaNombreLenght : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Personas",
                type: "nvarchar(220)",
                maxLength: 220,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Personas",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(220)",
                oldMaxLength: 220);
        }
    }
}
