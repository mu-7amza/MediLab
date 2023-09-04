using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManager.Data.Migrations
{
    public partial class AddUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Users_DoctorId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_userId",
                table: "Appointments",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Users_userId",
                table: "Appointments",
                column: "userId",
                principalSchema: "security",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Users_userId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_userId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Appointments");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Users_DoctorId",
                table: "Appointments",
                column: "DoctorId",
                principalSchema: "security",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
