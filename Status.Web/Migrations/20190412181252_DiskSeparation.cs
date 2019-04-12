using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Status.Web.Migrations
{
    public partial class DiskSeparation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disk",
                table: "Readings");

            migrationBuilder.CreateTable(
                name: "Disks",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    DeviceID = table.Column<string>(nullable: true),
                    Size = table.Column<long>(nullable: false),
                    FreeSpace = table.Column<long>(nullable: false),
                    ReadingID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Disks_Readings_ReadingID",
                        column: x => x.ReadingID,
                        principalTable: "Readings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Disks_ReadingID",
                table: "Disks",
                column: "ReadingID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Disks");

            migrationBuilder.AddColumn<int>(
                name: "Disk",
                table: "Readings",
                nullable: false,
                defaultValue: 0);
        }
    }
}
