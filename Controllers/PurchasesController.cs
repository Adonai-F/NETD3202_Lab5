using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab5.Models;

namespace Lab5.Controllers
{
    public class PurchasesController : Controller
    {
        private readonly InventoryContex _context;

        public PurchasesController(InventoryContex context)
        {
            _context = context;
        }

        // GET: Purchases
        public async Task<IActionResult> Index()
        {
            return View(await _context.Orders.ToListAsync());
        }

        // GET: Purchases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchased = await _context.Orders
                .FirstOrDefaultAsync(m => m.purchasedId == id);
            if (purchased == null)
            {
                return NotFound();
            }

            return View(purchased);
        }

        // GET: Purchases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Purchases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("purchasedId,itemPurchased,customerName,phoneNumber,address")] Purchased purchased)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchased);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(purchased);
        }

        // GET: Purchases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchased = await _context.Orders.FindAsync(id);
            if (purchased == null)
            {
                return NotFound();
            }
            return View(purchased);
        }

        // POST: Purchases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("purchasedId,itemPurchased,customerName,phoneNumber,address")] Purchased purchased)
        {
            if (id != purchased.purchasedId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchased);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchasedExists(purchased.purchasedId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(purchased);
        }

        // GET: Purchases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchased = await _context.Orders
                .FirstOrDefaultAsync(m => m.purchasedId == id);
            if (purchased == null)
            {
                return NotFound();
            }

            return View(purchased);
        }

        // POST: Purchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchased = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(purchased);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchasedExists(int id)
        {
            return _context.Orders.Any(e => e.purchasedId == id);
        }
    }
}
