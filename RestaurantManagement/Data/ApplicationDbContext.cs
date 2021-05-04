﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Catetgories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
    }
}