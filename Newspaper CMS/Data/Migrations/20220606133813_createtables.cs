using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Newspaper_CMS.Data.Migrations
{
    public partial class createtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Article_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Article_Title = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Article_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Writer_ID = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Article_PublishDate = table.Column<DateTime>(type: "date", nullable: true),
                    Article_Active = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Article_ID);
                    table.ForeignKey(
                        name: "FK_Articles_AspNetUsers",
                        column: x => x.Writer_ID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Category_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Category_ID);
                });

            migrationBuilder.CreateTable(
                name: "Article_Category",
                columns: table => new
                {
                    Article_ID = table.Column<int>(type: "int", nullable: false),
                    Category_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article_Category", x => new { x.Article_ID, x.Category_ID });
                    table.ForeignKey(
                        name: "FK_Article_Category_Articles",
                        column: x => x.Article_ID,
                        principalTable: "Articles",
                        principalColumn: "Article_ID");
                    table.ForeignKey(
                        name: "FK_Article_Category_Category",
                        column: x => x.Category_ID,
                        principalTable: "Category",
                        principalColumn: "Category_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_Category_Category_ID",
                table: "Article_Category",
                column: "Category_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_Writer_ID",
                table: "Articles",
                column: "Writer_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article_Category");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "AspNetUsers",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
