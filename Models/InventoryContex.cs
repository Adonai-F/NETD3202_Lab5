using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lab5.Models
{
    public class InventoryContex : DbContext
    {
        public InventoryContex(DbContextOptions<InventoryContex> options) : base(options)
        {

        }

        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Purchased> Orders { get; set; }
    }
}
