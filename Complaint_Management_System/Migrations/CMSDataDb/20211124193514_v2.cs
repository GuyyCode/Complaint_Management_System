using Microsoft.EntityFrameworkCore.Migrations;

namespace Complaint_Management_System.Migrations.CMSDataDb
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastName",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "UserProfile");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "UserProfile",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "UserProfile");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "UserProfile",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "UserProfile",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
