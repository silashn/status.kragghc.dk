using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Status.Web.Migrations
{
    public partial class CreatedDateTimeToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Created",
                table: "Readings",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Readings",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
