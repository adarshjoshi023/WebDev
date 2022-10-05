using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GG.Data.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sport",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sportName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sport", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Playground",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    groundName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sportId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playground", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Playground_Sport_sportId",
                        column: x => x.sportId,
                        principalTable: "Sport",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    playerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    skillLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    groundId = table.Column<int>(type: "int", nullable: true),
                    sportId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_Playground_groundId",
                        column: x => x.groundId,
                        principalTable: "Playground",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Player_Sport_sportId",
                        column: x => x.sportId,
                        principalTable: "Sport",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Refree",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    refreeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    refreeNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    groundId = table.Column<int>(type: "int", nullable: true),
                    sportId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refree", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Refree_Playground_groundId",
                        column: x => x.groundId,
                        principalTable: "Playground",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Refree_Sport_sportId",
                        column: x => x.sportId,
                        principalTable: "Sport",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Player_groundId",
                table: "Player",
                column: "groundId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_sportId",
                table: "Player",
                column: "sportId");

            migrationBuilder.CreateIndex(
                name: "IX_Playground_sportId",
                table: "Playground",
                column: "sportId");

            migrationBuilder.CreateIndex(
                name: "IX_Refree_groundId",
                table: "Refree",
                column: "groundId");

            migrationBuilder.CreateIndex(
                name: "IX_Refree_sportId",
                table: "Refree",
                column: "sportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Refree");

            migrationBuilder.DropTable(
                name: "Playground");

            migrationBuilder.DropTable(
                name: "Sport");
        }
    }
}
