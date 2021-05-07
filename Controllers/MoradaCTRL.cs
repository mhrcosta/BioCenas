using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BioCenas.Data;
using BioCenas.Models;

namespace BioCenas.Controllers
{
    public class MoradaCTRL : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoradaCTRL(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MoradaCTRL
        public async Task<IActionResult> Index()
        {
            return View(await _context.Moradas.ToListAsync());
        }

        // GET: MoradaCTRL/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moradaMDL = await _context.Moradas
                .FirstOrDefaultAsync(m => m.ID_Morada == id);
            if (moradaMDL == null)
            {
                return NotFound();
            }

            return View(moradaMDL);
        }

        // GET: MoradaCTRL/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MoradaCTRL/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Morada,Morada,CodigoPostal")] MoradaMDL moradaMDL)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moradaMDL);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(moradaMDL);
        }

        // GET: MoradaCTRL/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moradaMDL = await _context.Moradas.FindAsync(id);
            if (moradaMDL == null)
            {
                return NotFound();
            }
            return View(moradaMDL);
        }

        // POST: MoradaCTRL/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Morada,Morada,CodigoPostal")] MoradaMDL moradaMDL)
        {
            if (id != moradaMDL.ID_Morada)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moradaMDL);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoradaMDLExists(moradaMDL.ID_Morada))
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
            return View(moradaMDL);
        }

        // GET: MoradaCTRL/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moradaMDL = await _context.Moradas
                .FirstOrDefaultAsync(m => m.ID_Morada == id);
            if (moradaMDL == null)
            {
                return NotFound();
            }

            return View(moradaMDL);
        }

        // POST: MoradaCTRL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var moradaMDL = await _context.Moradas.FindAsync(id);
            _context.Moradas.Remove(moradaMDL);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoradaMDLExists(int id)
        {
            return _context.Moradas.Any(e => e.ID_Morada == id);
        }
    }
}
