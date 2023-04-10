using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UrlShortener.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "ShortUrl");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "ShortUrl");

            migrationBuilder.DropColumn(
                name: "ShortUrls",
                table: "ShortUrl");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "ShortUrl",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ShortenUrl",
                table: "ShortUrl",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "ShortUrl");

            migrationBuilder.DropColumn(
                name: "ShortenUrl",
                table: "ShortUrl");

            migrationBuilder.AddColumn<string>(
                name: "LastModificationTime",
                table: "ShortUrl",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifierId",
                table: "ShortUrl",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortUrls",
                table: "ShortUrl",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
