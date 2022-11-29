using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scheduler.Migrations
{
    public partial class Added_Tables_Roles_Users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFirstHalf",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "IsSecondHalf",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "RecurrenceException",
                table: "Schedule");

            migrationBuilder.RenameColumn(
                name: "RecurrenceRule",
                table: "Schedule",
                newName: "HalfDay");

            migrationBuilder.RenameColumn(
                name: "RecurrenceID",
                table: "Schedule",
                newName: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HalfDay",
                table: "Schedule",
                newName: "RecurrenceRule");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Schedule",
                newName: "RecurrenceID");

            migrationBuilder.AddColumn<bool>(
                name: "IsFirstHalf",
                table: "Schedule",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSecondHalf",
                table: "Schedule",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RecurrenceException",
                table: "Schedule",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
