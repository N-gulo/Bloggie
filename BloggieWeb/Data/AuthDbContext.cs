using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BloggieWeb.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);



            var adminRoleId = "052eaedd-dda8-40da-ac87-93ee5154955c";
            var superAdminRoleId = "37a43c73-06d8-4e62-aa1d-c290d57f27e8"; 
            var userRoleID = "a3cc5615-54e3-4c2b-a91d-51df429a9925";
            // seed Roles (User, Admin ,SuperAdmin)
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId
                },
                new IdentityRole
                {
                    Name ="SuperAdmin",
                    NormalizedName ="SuperAdmin",
                    Id = superAdminRoleId,
                    ConcurrencyStamp = superAdminRoleId
                },
                new IdentityRole 
                {
                    Name ="User",
                    NormalizedName ="User",
                    Id = userRoleID,
                    ConcurrencyStamp = userRoleID
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);


            // seed SuperAdminUser
            var superAdminId = "4fce519d-d0c5-4ebf-94ae-35db4637546a";

            var superAdminUser = new IdentityUser
            {
                UserName = "superadmin@bloggie.com",
                Email = "superadmin@bloggie.com",
                NormalizedEmail = "superadmin@bloggie.com".ToUpper(),
                NormalizedUserName = "superadmin@bloggie.com".ToUpper(),
                Id = superAdminId,
            };

            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(superAdminUser, "Superadmin@123");

            builder.Entity<IdentityUser>().HasData(superAdminUser);

            // Add All roles to SuperAdmin User
            var superAdminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string> 
                {
                    RoleId = adminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = superAdminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = userRoleID,
                    UserId = superAdminId
                }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);
        }
    }
}
