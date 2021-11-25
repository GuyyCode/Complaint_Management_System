using Microsoft.EntityFrameworkCore.Migrations;

namespace Complaint_Management_System.Migrations.CMSDataDb
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentNo",
                table: "UserProfile",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentNo",
                table: "UserProfile");
        }
    }
}
