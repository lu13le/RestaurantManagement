﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Data;
using RestaurantManagement.Models;
using RestaurantManagement.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.ManagerUser)]
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        //GET Action Method-List of Categories
        public async Task <IActionResult> Index()
        {
            return View(await _db.Catetgories.ToListAsync());
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                //if valid
                _db.Catetgories.Add(category);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }
            return View(category);
        }

        //GET - EDIT
        public async Task <IActionResult> Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var category = await _db.Catetgories.FindAsync(id);
            if(category==null)
            {
                return NotFound();
            }
            return View(category);
        }

        //POST - EDIT

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Edit(Category category)
        {
            if(ModelState.IsValid)
            {
                //if is valid
                _db.Update(category);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        //GET - DELETE

        public async Task <IActionResult> Delete(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var category = await _db.Catetgories.FindAsync(id);
            if(category==null)
            {
                return NotFound();
            }
            return View(category);
        }

        //POST - DELETE

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var category = await _db.Catetgories.FindAsync(id);

            if(category==null)
            {
                return View();
            }
            _db.Catetgories.Remove(category);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //GET - DETAILS
        public async Task <IActionResult> Details(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var category = await _db.Catetgories.FindAsync(id);
            if(category==null)
            {
                return NotFound();
            }
            return View(category);
        }
    }
}
