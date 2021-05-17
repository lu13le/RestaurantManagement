using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestaurantManagement.Data;
using RestaurantManagement.Models;
using RestaurantManagement.Models.ViewModels;
using RestaurantManagement.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RestaurantManagement.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        //Index page of project
        public async Task <IActionResult> Index()
        {
            IndexViewModel IndexVM = new IndexViewModel()
            {
                MenuItems = await _db.MenuItems.Include(m => m.Category).Include(m => m.Subcategory).ToListAsync(),
                Categories = await _db.Catetgories.ToListAsync(),
                Coupons = await _db.Coupons.Where(c => c.IsActive == true).ToListAsync()

            };

            var claimsIndentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIndentity.FindFirst(ClaimTypes.NameIdentifier);

            if(claim!=null)
            {
                var count = _db.ShoppingCarts.Where(u => u.ApplicationUserId == claim.Value).ToList().Count;
                HttpContext.Session.SetInt32(SD.ssShoppingCartCount, count);
            }

            return View(IndexVM);
        }
        //GET- Details
        [Authorize]
        public async Task<IActionResult>Details(int id)
        {
            var menuItemFromDb = await _db.MenuItems.Include(m => m.Category).Include(m => m.Subcategory).Where(m => m.Id == id).FirstOrDefaultAsync();

            ShoppingCart cartObj = new ShoppingCart()
            {
                MenuItem = menuItemFromDb,
                MenuItemId = menuItemFromDb.Id
            };
            return View(cartObj);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task <IActionResult> Details(ShoppingCart CartObject)
        {
            CartObject.Id = 0;
            if(ModelState.IsValid)
            {
                var claimsIdentity = (ClaimsIdentity)this.User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                CartObject.ApplicationUserId = claim.Value;


                ShoppingCart cartFromDb = await _db.ShoppingCarts.Where(c => c.ApplicationUserId == CartObject.ApplicationUserId && c.MenuItemId== CartObject.MenuItemId).FirstOrDefaultAsync();

                if(cartFromDb==null)
                {
                    await _db.ShoppingCarts.AddAsync(CartObject);
                }
                else
                {
                    cartFromDb.Count = cartFromDb.Count + CartObject.Count;
                }
                await _db.SaveChangesAsync();

                var count = _db.ShoppingCarts.Where(c => c.ApplicationUserId == CartObject.ApplicationUserId).ToList().Count();

                HttpContext.Session.SetInt32(SD.ssShoppingCartCount, count);

                return RedirectToAction("Index");


            }
            else
            {
                var menuItemFromDb = await _db.MenuItems.Include(m => m.Category).Include(m => m.Subcategory).Where(m => m.Id == CartObject.MenuItemId).FirstOrDefaultAsync();

                ShoppingCart cartObj = new ShoppingCart()
                {
                    MenuItem = menuItemFromDb,
                    MenuItemId = menuItemFromDb.Id
                };
                return View(cartObj);
            }
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
    }
}
