using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QuanLyPhongBan.Areas.Identity.Data;
using QuanLyPhongBan.Data;
using QuanLyPhongBan.Entities;
using QuanLyPhongBan.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyPhongBan.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QuanLyPhongBanContext _context;

        public HomeController(ILogger<HomeController> logger, QuanLyPhongBanContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ManagerDepartment()
        {
            return View(await _context.PhongBans.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPhongBan,TenPhongBan,HoSo")] Entities.PhongBan phongBan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phongBan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phongBan);
        }

        public async Task<IActionResult> DetailUserInDepartment(int id)
        {

            var listUser = _context.Users.Where(x => x.IdPhongban == id).
                Select( x => new UserViewModel {
                Id = x.Id,
                UserName = x.UserName,
                Email = x.Email,
                IdPhongBan = x.IdPhongban,
                ChucVu = x.ChucVu
                }).
                ToList();
            if(listUser == null)
            {
                return View("Error.html");
            }
            else
            {
                return View(listUser);

            }

        }

        public async Task<IActionResult> DetailsOfUser(string id)
        {

            var listUser = _context.Users.Where(x => x.Id == id).
                Select(x => new UserViewModel
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    Email = x.Email,
                    IdPhongBan = x.IdPhongban,
                    ChucVu = x.ChucVu
                }).FirstOrDefault();

            if (listUser == null)
            {
                return View("Error.html");
            }
            else
            {
                return View(listUser);

            }

        }

        public async Task<IActionResult> EditDepartment(int id)
        {
            var user = _context.PhongBans.Where(x => x.IdPhongban == id).
                Select(x => new PhongBan
                {
                    IdPhongban = x.IdPhongban,
                    TenPhongBan = x.TenPhongBan,
                    HoSo = x.HoSo,
                }).FirstOrDefault();
            return View(user);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDepartment([Bind("IdPhongban,TenPhongBan,HoSo")] Entities.PhongBan phongBan)
        {
            try
            {

                var result = _context.PhongBans.Update(phongBan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditUserInDepartment(string id)
        {
            var user = _context.Users.Where(x => x.Id == id).
                Select(x => new UserViewModel
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    IdPhongBan = x.IdPhongban,
                    ChucVu = x.ChucVu,
                }).FirstOrDefault();
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUserInDepartment(string id, IFormCollection collection)
        {
            try
            {
                var user = _context.Users.Where(x => x.Id == id).FirstOrDefault();
                user.UserName = collection["UserName"];
                user.Email = collection["Email"];
                user.PhoneNumber = collection["PhoneNumber"];
                user.IdPhongban = int.Parse(collection["IdPhongBan"]);
                user.ChucVu = collection["ChucVu"];

                var result = _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        public async Task<IActionResult> DeleteDepartment(int id)
        {

            
            var user = _context.PhongBans.Where(x => x.IdPhongban == id).
                Select(x => new PhongBan
                {
                    IdPhongban = x.IdPhongban,
                    TenPhongBan = x.TenPhongBan,
                    HoSo = x.HoSo,
                }).FirstOrDefault();
            return View(user);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteDepartment(int id, IFormCollection collection)
        {
            
            try
            {
                var phongban = _context.PhongBans.Where(x => x.IdPhongban == id).FirstOrDefault();
                var result = _context.PhongBans.Remove(phongban);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        public async Task<IActionResult> DeleteUserInDepartment(string id)
        {
            var user = _context.Users.Where(x => x.Id == id).
                Select(x => new UserViewModel
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    IdPhongBan = x.IdPhongban,
                    ChucVu = x.ChucVu,
                }).FirstOrDefault();
            return View(user);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUserInDepartment(string id, IFormCollection collection)
        {
            try
            {
                var user = _context.Users.Where(x => x.Id == id).FirstOrDefault();
                user.UserName = collection["UserName"];
                user.Email = collection["Email"];
                user.PhoneNumber = collection["PhoneNumber"];
                user.IdPhongban = 1;
                user.ChucVu = "NhanSu";

                var result = _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}
