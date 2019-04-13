using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Status.Web.Migrations
{
    public partial class CreatedToDateTime_AddTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Readings",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "Readings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Readings");

            migrationBuilder.AlterColumn<string>(
                name: "Created",
                table: "Readings",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
