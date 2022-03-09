using Microsoft.EntityFrameworkCore.Migrations;

namespace Finalproject.Migrations
{
    public partial class init123456 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Specials",
                newName: "Brand");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Brand",
                table: "Specials",
                newName: "Name");
        }
    }
}
