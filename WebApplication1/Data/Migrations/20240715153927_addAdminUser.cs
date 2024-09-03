using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Data.Migrations
{
    /// <inheritdoc />
    public partial class addAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [Security].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Address], [CreatedAt], [FirstName], [LastName], [ProfilePicture]) VALUES (N'df1d46cc-965f-4cde-9485-8b4a6f411f96', N'admin@hguid.com', N'ADMIN@HGUID.COM', N'admin@hguid.com', N'ADMIN@HGUID.COM', 0, N'AQAAAAIAAYagAAAAEGOmINI5qM5iGrPO9NkGY2VirkRdRmTJIewI9GFQy+uxNsfFO70xY469KqxFyKwh/g==', N'JD3BMP3Q2FRIQAXI5KUBKO2M3FXLZLPU', N'd181dd7f-6eaa-4d89-9d57-3d413ce672f6', N'+96393333333', 0, 0, NULL, 1, 0, N'Healing Guide', N'2024-07-15 18:35:55', N'Super', N'Admin', NULL)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [Security].[Users] WHERE Id='df1d46cc-965f-4cde-9485-8b4a6f411f96'");
        }
    }
}
