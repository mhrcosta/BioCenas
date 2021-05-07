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
    public class RestricaoAlimentarCTRL : Controller
    {
        private readonly ApplicationDbContext _context;

        public RestricaoAlimentarCTRL(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RestricaoAlimentarCTRL
        public async Task<IActionResult> Index()
        {
            return View(await _context.RestricaoAlimentares.ToListAsync());
        }

        // GET: RestricaoAlimentarCTRL/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restricaoAlimentarMDL = await _context.RestricaoAlimentares
                .FirstOrDefaultAsync(m => m.ID_RestricaoAlimentar == id);
            if (restricaoAlimentarMDL == null)
            {
                return NotFound();
            }

            return View(restricaoAlimentarMDL);
        }

        // GET: RestricaoAlimentarCTRL/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RestricaoAlimentarCTRL/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_RestricaoAlimentar,DesignacaoRestricaoAlimentar,DescricaoRestricaoAlimentar")] RestricaoAlimentarMDL restricaoAlimentarMDL)
        {
            if (ModelState.IsValid)
            {
                _context.Add(restricaoAlimentarMDL);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(restricaoAlimentarMDL);
        }

        // GET: RestricaoAlimentarCTRL/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restricaoAlimentarMDL = await _context.RestricaoAlimentares.FindAsync(id);
            if (restricaoAlimentarMDL == null)
            {
                return NotFound();
            }
            return View(restricaoAlimentarMDL);
        }

        // POST: RestricaoAlimentarCTRL/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_RestricaoAlimentar,DesignacaoRestricaoAlimentar,DescricaoRestricaoAlimentar")] RestricaoAlimentarMDL restricaoAlimentarMDL)
        {
            if (id != restricaoAlimentarMDL.ID_RestricaoAlimentar)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(restricaoAlimentarMDL);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestricaoAlimentarMDLExists(restricaoAlimentarMDL.ID_RestricaoAlimentar))
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
            return View(restricaoAlimentarMDL);
        }

        // GET: RestricaoAlimentarCTRL/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restricaoAlimentarMDL = await _context.RestricaoAlimentares
                .FirstOrDefaultAsync(m => m.ID_RestricaoAlimentar == id);
            if (restricaoAlimentarMDL == null)
            {
                return NotFound();
            }

            return View(restricaoAlimentarMDL);
        }

        // POST: RestricaoAlimentarCTRL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var restricaoAlimentarMDL = await _context.RestricaoAlimentares.FindAsync(id);
            _context.RestricaoAlimentares.Remove(restricaoAlimentarMDL);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RestricaoAlimentarMDLExists(int id)
        {
            return _context.RestricaoAlimentares.Any(e => e.ID_RestricaoAlimentar == id);
        }
    }
}
