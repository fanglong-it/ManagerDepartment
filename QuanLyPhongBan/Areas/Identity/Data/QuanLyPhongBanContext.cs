using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuanLyPhongBan.Areas.Identity.Data;
using QuanLyPhongBan.Entities;

namespace QuanLyPhongBan.Data
{
    public class QuanLyPhongBanContext : IdentityDbContext<QuanLyPhongBanUser>
    {
        public QuanLyPhongBanContext(DbContextOptions<QuanLyPhongBanContext> options)
            : base(options)
        {
        }


        public DbSet<PhongBan> PhongBans { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            this.SeedRoles(builder);
            this.SeedUser(builder);
            this.SeedUserToRole(builder);

            builder.Entity<PhongBan>().HasData(
                new PhongBan() { IdPhongban = 1, TenPhongBan = "Lab", HoSo = "HoSo" },
                new PhongBan() { IdPhongban = 2, TenPhongBan = "NhanSu", HoSo = "HoSo" },
                new PhongBan() { IdPhongban = 3, TenPhongBan = "KinhDoanh", HoSo = "HoSo" }
                );
        }


        //Tao roles
        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = "fab4fac1-c546-41de-aebc-a14da6895711",
                    Name = "Admin",
                    //ConcurrencyStamp = "1",
                    NormalizedName = "Admin"
                }

                );
        }

        private void SeedUser(ModelBuilder builder)
        {
            QuanLyPhongBanUser user = new QuanLyPhongBanUser()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "admin@abc.com",
                NormalizedUserName = "admin@abc.com",

                Email = "admin@abc.com",
                NormalizedEmail = "admin@abc.com",
                LockoutEnabled = false,
                PhoneNumber = "1234567890",
                IdPhongban = 1,

                SecurityStamp = Guid.NewGuid().ToString(),

            };
            PasswordHasher<QuanLyPhongBanUser> pHash = new PasswordHasher<QuanLyPhongBanUser>();
            user.PasswordHash = pHash.HashPassword(user, "Admin*123");
            user.EmailConfirmed = true;
            builder.Entity<QuanLyPhongBanUser>().HasData(user);

        }

        // Gan User vo Role
        private void SeedUserToRole(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = "fab4fac1-c546-41de-aebc-a14da6895711",
                    UserId = "b74ddd14-6340-4840-95c2-db12554843e5"
                }

                );

        }
    }
}
