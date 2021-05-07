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
    public class EncomendaCTRL : Controller
    {
        private readonly ApplicationDbContext _context;

        public EncomendaCTRL(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EncomendaCTRL
        public async Task<IActionResult> Index()
        {
            return View(await _context.Encomendas.ToListAsync());
        }

        // GET: EncomendaCTRL/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encomendaMDL = await _context.Encomendas
                .FirstOrDefaultAsync(m => m.ID_Encomenda == id);
            if (encomendaMDL == null)
            {
                return NotFound();
            }

            return View(encomendaMDL);
        }

        // GET: EncomendaCTRL/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EncomendaCTRL/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Encomenda,ID_DescritivoEncomenda,ID_Cliente,ID_LocalEntrega,DataEntrega")] EncomendaMDL encomendaMDL)
        {
            if (ModelState.IsValid)
            {
                _context.Add(encomendaMDL);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(encomendaMDL);
        }

        // GET: EncomendaCTRL/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encomendaMDL = await _context.Encomendas.FindAsync(id);
            if (encomendaMDL == null)
            {
                return NotFound();
            }
            return View(encomendaMDL);
        }

        // POST: EncomendaCTRL/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Encomenda,ID_DescritivoEncomenda,ID_Cliente,ID_LocalEntrega,DataEntrega")] EncomendaMDL encomendaMDL)
        {
            if (id != encomendaMDL.ID_Encomenda)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(encomendaMDL);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EncomendaMDLExists(encomendaMDL.ID_Encomenda))
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
            return View(encomendaMDL);
        }

        // GET: EncomendaCTRL/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encomendaMDL = await _context.Encomendas
                .FirstOrDefaultAsync(m => m.ID_Encomenda == id);
            if (encomendaMDL == null)
            {
                return NotFound();
            }

            return View(encomendaMDL);
        }

        // POST: EncomendaCTRL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var encomendaMDL = await _context.Encomendas.FindAsync(id);
            _context.Encomendas.Remove(encomendaMDL);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EncomendaMDLExists(int id)
        {
            return _context.Encomendas.Any(e => e.ID_Encomenda == id);
        }
    }
}
