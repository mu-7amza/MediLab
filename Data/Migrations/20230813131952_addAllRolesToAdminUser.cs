using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManager.Data.Migrations
{
    public partial class addAllRolesToAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT into [security].[UserRoles] (UserId,RoleId) SELECT 'ceba03fb-d843-43a9-b887-9f9a5d8a27d6',Id FROM [security].[Roles]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE from [security].[UserRoles] WHERE UserId = 'ceba03fb-d843-43a9-b887-9f9a5d8a27d6'");
        }
    }
}
