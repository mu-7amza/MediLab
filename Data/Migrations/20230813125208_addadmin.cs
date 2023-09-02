using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManager.Data.Migrations
{
    public partial class addadmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [security].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [ProfilePicture]) VALUES (N'ceba03fb-d843-43a9-b887-9f9a5d8a27d6', N'admin', N'ADMIN', N'admin@admin.com', N'ADMIN@ADMIN.COM', 0, N'AQAAAAEAACcQAAAAEPVxYAyfCbA3PRYygCwJxVqTHCA/QZJyhpQanCtNTyXVcNPnkHxCLrAf4N9/K4jgdQ==', N'PE6FTRFWCTURC2M3PUODKAPUCGK5DSQJ', N'da4fa742-ec5d-42e3-98ca-8fd18cc6cf3b', NULL, 0, 0, NULL, 1, 0, N'Muhammed', N'Hamzawy', null)\r\n");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [security].[Users] WHERE Id = 'ceba03fb-d843-43a9-b887-9f9a5d8a27d6'");
        }
    }
}
