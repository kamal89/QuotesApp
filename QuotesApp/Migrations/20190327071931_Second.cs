using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuotesApp.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "ReleaseYear",
                table: "Movie",
                nullable: false,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseYear",
                table: "Movie",
                nullable: false,
                oldClrType: typeof(short));
        }
    }
}
