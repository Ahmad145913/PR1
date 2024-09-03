using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Data.Migrations
{
    /// <inheritdoc />
    public partial class fMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "FacilityTypes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Longitude = table.Column<float>(type: "real", nullable: true),
                    Latitude = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalDepartments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalDepartments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Physicians",
                columns: table => new
                {
                    PhysicianId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Physicians", x => x.PhysicianId);
                    table.ForeignKey(
                        name: "FK_Physicians_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourceCategories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserViewModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Roles = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalFacilities",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LocationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ManagerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FacilityTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmergencyNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FaxNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalFacilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalFacilities_FacilityTypes_FacilityTypeId",
                        column: x => x.FacilityTypeId,
                        principalTable: "FacilityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalFacilities_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalFacilities_Users_ManagerId",
                        column: x => x.ManagerId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalFacilities_FacilityTypeId",
                table: "MedicalFacilities",
                column: "FacilityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalFacilities_LocationId",
                table: "MedicalFacilities",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalFacilities_ManagerId",
                table: "MedicalFacilities",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Physicians_UserId",
                table: "Physicians",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalDepartments");

            migrationBuilder.DropTable(
                name: "MedicalFacilities");

            migrationBuilder.DropTable(
                name: "Physicians");

            migrationBuilder.DropTable(
                name: "ResourceCategories");

            migrationBuilder.DropTable(
                name: "UserViewModel");

            migrationBuilder.DropTable(
                name: "FacilityTypes");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropColumn(
                name: "isActive",
                schema: "Security",
                table: "Users");
        }
    }
}
