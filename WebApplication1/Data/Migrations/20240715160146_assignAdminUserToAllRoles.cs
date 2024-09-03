using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Data.Migrations
{
    /// <inheritdoc />
    public partial class assignAdminUserToAllRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [Security].[UserRoles] (UserId, RoleId) SELECT 'df1d46cc-965f-4cde-9485-8b4a6f411f96' ,Id FROM [Security].[Roles]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [Security].[UserRoles] WHERE UserId = 'df1d46cc-965f-4cde-9485-8b4a6f411f96'");
        }
    }
}
