using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class payy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Tbl_Profiles");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Tbl_Profiles");

            migrationBuilder.AddColumn<int>(
                name: "Amonnt",
                table: "Tbl_Profiles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Tbl_Profiles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Tbl_Profiles",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Tbl_Profiles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Tel",
                table: "Tbl_Profiles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amonnt",
                table: "Tbl_Profiles");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Tbl_Profiles");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Tbl_Profiles");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tbl_Profiles");

            migrationBuilder.DropColumn(
                name: "Tel",
                table: "Tbl_Profiles");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Tbl_Profiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Tbl_Profiles",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
