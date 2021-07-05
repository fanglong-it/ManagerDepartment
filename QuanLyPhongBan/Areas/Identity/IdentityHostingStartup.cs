using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuanLyPhongBan.Areas.Identity.Data;
using QuanLyPhongBan.Data;

[assembly: HostingStartup(typeof(QuanLyPhongBan.Areas.Identity.IdentityHostingStartup))]
namespace QuanLyPhongBan.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<QuanLyPhongBanContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("QuanLyPhongBanContextConnection")));

                services.AddDefaultIdentity<QuanLyPhongBanUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<QuanLyPhongBanContext>();
            });
        }
    }
}