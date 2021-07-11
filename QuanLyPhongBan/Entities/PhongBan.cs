using QuanLyPhongBan.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyPhongBan.Entities
{
    public class PhongBan
    {

        [Key]
        public int IdPhongban { get; set; }

        public string TenPhongBan { get; set; }

        public string HoSo { get; set; }

        public ICollection<QuanLyPhongBanUser> quanLyPhongBanUsers { get; set; }

    }
}
