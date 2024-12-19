using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Etablissements",
                columns: table => new
                {
                    idetab = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    e_Nom = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etablissements", x => x.idetab);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    idStatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    s_Nom = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.idStatus);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Challenges",
                columns: table => new
                {
                    idChal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    c_Status = table.Column<int>(type: "int", nullable: false),
                    c_libelle = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    c_Desc = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    c_NbPoint = table.Column<int>(type: "int", nullable: false),
                    c_step = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenges", x => x.idChal);
                    table.ForeignKey(
                        name: "FK_Challenges_Status_c_Status",
                        column: x => x.c_Status,
                        principalTable: "Status",
                        principalColumn: "idStatus",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    u_Nom = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    u_Mail = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    u_Password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idgroupe = table.Column<int>(type: "int", nullable: false),
                    u_NbPoint = table.Column<int>(type: "int", nullable: false),
                    u_idEtab = table.Column<int>(type: "int", nullable: false),
                    idStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.idUser);
                    table.ForeignKey(
                        name: "FK_Users_Etablissements_u_idEtab",
                        column: x => x.u_idEtab,
                        principalTable: "Etablissements",
                        principalColumn: "idetab",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Status_idgroupe",
                        column: x => x.idgroupe,
                        principalTable: "Status",
                        principalColumn: "idStatus",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    idQuestion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idChal = table.Column<int>(type: "int", nullable: false),
                    q_question = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    q_reponse = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    q_point = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.idQuestion);
                    table.ForeignKey(
                        name: "FK_Questions_Challenges_idChal",
                        column: x => x.idChal,
                        principalTable: "Challenges",
                        principalColumn: "idChal",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Challenge_Done",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "int", nullable: false),
                    idChal = table.Column<int>(type: "int", nullable: false),
                    cd_done = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    cd_step = table.Column<int>(type: "int", nullable: true),
                    idImgChal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenge_Done", x => new { x.idUser, x.idChal });
                    table.ForeignKey(
                        name: "FK_Challenge_Done_Challenges_idChal",
                        column: x => x.idChal,
                        principalTable: "Challenges",
                        principalColumn: "idChal",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Challenge_Done_Users_idUser",
                        column: x => x.idUser,
                        principalTable: "Users",
                        principalColumn: "idUser",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ImageChallenges",
                columns: table => new
                {
                    id_ic = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ic_image = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ic_desc = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idUser_catch = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageChallenges", x => x.id_ic);
                    table.ForeignKey(
                        name: "FK_ImageChallenges_Users_idUser_catch",
                        column: x => x.idUser_catch,
                        principalTable: "Users",
                        principalColumn: "idUser",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Challenge_Done_idChal",
                table: "Challenge_Done",
                column: "idChal");

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_c_Status",
                table: "Challenges",
                column: "c_Status");

            migrationBuilder.CreateIndex(
                name: "IX_ImageChallenges_idUser_catch",
                table: "ImageChallenges",
                column: "idUser_catch");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_idChal",
                table: "Questions",
                column: "idChal");

            migrationBuilder.CreateIndex(
                name: "IX_Users_idgroupe",
                table: "Users",
                column: "idgroupe");

            migrationBuilder.CreateIndex(
                name: "IX_Users_u_idEtab",
                table: "Users",
                column: "u_idEtab");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Challenge_Done");

            migrationBuilder.DropTable(
                name: "ImageChallenges");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Challenges");

            migrationBuilder.DropTable(
                name: "Etablissements");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
