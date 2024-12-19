using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AddUserSucces : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Succes",
                columns: table => new
                {
                    idSucces = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    pointrequired = table.Column<int>(type: "int", nullable: false),
                    libelleSucces = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Succes", x => x.idSucces);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserSucces",
                columns: table => new
                {
                    idUserSucces = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idUser = table.Column<int>(type: "int", nullable: false),
                    idSucces = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSucces", x => x.idUserSucces);
                    table.ForeignKey(
                        name: "FK_UserSucces_Succes_idSucces",
                        column: x => x.idSucces,
                        principalTable: "Succes",
                        principalColumn: "idSucces",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserSucces_Users_idUser",
                        column: x => x.idUser,
                        principalTable: "Users",
                        principalColumn: "idUser",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UserSucces_idSucces",
                table: "UserSucces",
                column: "idSucces");

            migrationBuilder.CreateIndex(
                name: "IX_UserSucces_idUser",
                table: "UserSucces",
                column: "idUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSucces");

            migrationBuilder.DropTable(
                name: "Succes");
        }
    }
}
