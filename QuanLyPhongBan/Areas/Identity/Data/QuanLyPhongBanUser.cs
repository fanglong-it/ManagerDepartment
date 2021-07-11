using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using QuanLyPhongBan.Entities;

namespace QuanLyPhongBan.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the QuanLyPhongBanUser class
    public class QuanLyPhongBanUser : IdentityUser
    {

       
        [PersonalData]
        [ForeignKey("phongBan")]
        public int IdPhongban { get; set; }

        public PhongBan phongBan { get; set; }


        public string ChucVu { get; set; }



    }
}
