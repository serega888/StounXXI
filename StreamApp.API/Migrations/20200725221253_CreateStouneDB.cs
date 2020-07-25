using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StreamApp.API.Migrations
{
    public partial class CreateStouneDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KursValutes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateKurs = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KursValutes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MyValutes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KursValuteId = table.Column<int>(nullable: false),
                    MyValuteId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyValutes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyValutes_KursValutes_KursValuteId",
                        column: x => x.KursValuteId,
                        principalTable: "KursValutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyValutes_KursValuteId",
                table: "MyValutes",
                column: "KursValuteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyValutes");

            migrationBuilder.DropTable(
                name: "KursValutes");
        }
    }
}
