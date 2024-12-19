using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserSuccesss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSucces",
                table: "UserSucces");

            migrationBuilder.DropIndex(
                name: "IX_UserSucces_idUser",
                table: "UserSucces");

            migrationBuilder.AlterColumn<int>(
                name: "idUserSucces",
                table: "UserSucces",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSucces",
                table: "UserSucces",
                columns: new[] { "idUser", "idSucces" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSucces",
                table: "UserSucces");

            migrationBuilder.AlterColumn<int>(
                name: "idUserSucces",
                table: "UserSucces",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSucces",
                table: "UserSucces",
                column: "idUserSucces");

            migrationBuilder.CreateIndex(
                name: "IX_UserSucces_idUser",
                table: "UserSucces",
                column: "idUser");
        }
    }
}
