/*
Communication Activity 5
December 12th, 2021
Adonai Ford-Williams
NETD3202
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// Use nuget manager
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
// importing from models folder
using Lab5.Models;

namespace Lab5.Data
{
    // Inherit from DbContext
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        //Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
        }

    }
}
