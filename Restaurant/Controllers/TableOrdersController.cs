using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Data.Entities;

namespace Restaurant.Controllers
{
    public class TableOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TableOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.TableOrders.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] TableOrder tableOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tableOrder);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
