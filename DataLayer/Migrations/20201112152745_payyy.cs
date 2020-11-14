using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class payyy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_Profiles",
                table: "Tbl_Profiles");

            migrationBuilder.RenameTable(
                name: "Tbl_Profiles",
                newName: "Tbl_Pays");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_Pays",
                table: "Tbl_Pays",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_Pays",
                table: "Tbl_Pays");

            migrationBuilder.RenameTable(
                name: "Tbl_Pays",
                newName: "Tbl_Profiles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_Profiles",
                table: "Tbl_Profiles",
                column: "Id");
        }
    }
}
