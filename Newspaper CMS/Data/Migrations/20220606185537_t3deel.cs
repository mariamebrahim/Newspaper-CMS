using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Newspaper_CMS.Data.Migrations
{
    public partial class t3deel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers",
                table: "Articles");

            migrationBuilder.DropTable(
                name: "Article_Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Articles_Writer_ID",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Category_ID",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
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

            migrationBuilder.DropColumn(
                name: "Writer_ID",
                table: "Articles");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Articles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category_Name",
                table: "Articles",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Writer_Name",
                table: "Articles",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category_1",
                table: "Category",
                column: "Category_Name");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ApplicationUserId",
                table: "Articles",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AspNetUsers_ApplicationUserId",
                table: "Articles",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers_ApplicationUserId",
                table: "Articles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category_1",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Articles_ApplicationUserId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Category_Name",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Writer_Name",
                table: "Articles");

            migrationBuilder.AddColumn<int>(
                name: "Category_ID",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddColumn<string>(
                name: "Writer_ID",
                table: "Articles",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Category_ID");

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
                name: "IX_Articles_Writer_ID",
                table: "Articles",
                column: "Writer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Article_Category_Category_ID",
                table: "Article_Category",
                column: "Category_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AspNetUsers",
                table: "Articles",
                column: "Writer_ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
