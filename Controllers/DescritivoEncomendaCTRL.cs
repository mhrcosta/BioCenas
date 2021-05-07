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
    public class DescritivoEncomendaCTRL : Controller
    {
        private readonly ApplicationDbContext _context;

        public DescritivoEncomendaCTRL(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DescritivoEncomendaCTRL
        public async Task<IActionResult> Index()
        {
            return View(await _context.DescritivoEncomendas.ToListAsync());
        }

        // GET: DescritivoEncomendaCTRL/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var descritivoEncomendaMDL = await _context.DescritivoEncomendas
                .FirstOrDefaultAsync(m => m.DescritivoEncomenda == id);
            if (descritivoEncomendaMDL == null)
            {
                return NotFound();
            }

            return View(descritivoEncomendaMDL);
        }

        // GET: DescritivoEncomendaCTRL/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DescritivoEncomendaCTRL/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DescritivoEncomenda,ID_Encomenda,ID_Produto,QTProduto")] DescritivoEncomendaMDL descritivoEncomendaMDL)
        {
            if (ModelState.IsValid)
            {
                _context.Add(descritivoEncomendaMDL);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(descritivoEncomendaMDL);
        }

        // GET: DescritivoEncomendaCTRL/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var descritivoEncomendaMDL = await _context.DescritivoEncomendas.FindAsync(id);
            if (descritivoEncomendaMDL == null)
            {
                return NotFound();
            }
            return View(descritivoEncomendaMDL);
        }

        // POST: DescritivoEncomendaCTRL/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DescritivoEncomenda,ID_Encomenda,ID_Produto,QTProduto")] DescritivoEncomendaMDL descritivoEncomendaMDL)
        {
            if (id != descritivoEncomendaMDL.DescritivoEncomenda)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(descritivoEncomendaMDL);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DescritivoEncomendaMDLExists(descritivoEncomendaMDL.DescritivoEncomenda))
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
            return View(descritivoEncomendaMDL);
        }

        // GET: DescritivoEncomendaCTRL/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var descritivoEncomendaMDL = await _context.DescritivoEncomendas
                .FirstOrDefaultAsync(m => m.DescritivoEncomenda == id);
            if (descritivoEncomendaMDL == null)
            {
                return NotFound();
            }

            return View(descritivoEncomendaMDL);
        }

        // POST: DescritivoEncomendaCTRL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var descritivoEncomendaMDL = await _context.DescritivoEncomendas.FindAsync(id);
            _context.DescritivoEncomendas.Remove(descritivoEncomendaMDL);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DescritivoEncomendaMDLExists(int id)
        {
            return _context.DescritivoEncomendas.Any(e => e.DescritivoEncomenda == id);
        }
    }
}
