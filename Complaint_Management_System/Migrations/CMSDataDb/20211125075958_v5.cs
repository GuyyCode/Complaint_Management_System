using Microsoft.EntityFrameworkCore.Migrations;

namespace Complaint_Management_System.Migrations.CMSDataDb
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentNo",
                table: "UserProfile");

            migrationBuilder.AddColumn<string>(
                name: "StaffStudentNo",
                table: "UserProfile",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StaffStudentNo",
                table: "UserProfile");

            migrationBuilder.AddColumn<string>(
                name: "StudentNo",
                table: "UserProfile",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
