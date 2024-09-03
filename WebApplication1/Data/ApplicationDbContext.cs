using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<FacilityType> FacilityTypes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<MedicalDepartment> MedicalDepartments { get; set; }
        public DbSet<MedicalFacility> MedicalFacilities { get; set; }
        public DbSet<Physician> Physicians { get; set; }
        public DbSet<ResourceCategory> ResourceCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("Users", "Security");
            builder.Entity<IdentityRole>().ToTable("Roles", "Security");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "Security");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "Security");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "Security");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim", "Security");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserToken", "Security");
        }
        public DbSet<WebApplication1.ViewModels.UserViewModel> UserViewModel { get; set; } = default!;
    }
}
