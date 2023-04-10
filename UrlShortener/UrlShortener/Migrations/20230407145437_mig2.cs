using Microsoft.EntityFrameworkCore.Migrations;

namespace UrlShortener.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortStringUrl",
                table: "ShortUrl",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortStringUrl",
                table: "ShortUrl");
        }
    }
}
