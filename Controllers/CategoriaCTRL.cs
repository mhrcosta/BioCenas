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
    public class CategoriaCTRL : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriaCTRL(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CategoriaCTRL
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categorias.ToListAsync());
        }

        // GET: CategoriaCTRL/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaMDL = await _context.Categorias
                .FirstOrDefaultAsync(m => m.ID_Categoria == id);
            if (categoriaMDL == null)
            {
                return NotFound();
            }

            return View(categoriaMDL);
        }

        // GET: CategoriaCTRL/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaCTRL/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Categoria,DesignacaoCategoria,DescricaoCategoria")] CategoriaMDL categoriaMDL)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaMDL);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaMDL);
        }

        // GET: CategoriaCTRL/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaMDL = await _context.Categorias.FindAsync(id);
            if (categoriaMDL == null)
            {
                return NotFound();
            }
            return View(categoriaMDL);
        }

        // POST: CategoriaCTRL/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Categoria,DesignacaoCategoria,DescricaoCategoria")] CategoriaMDL categoriaMDL)
        {
            if (id != categoriaMDL.ID_Categoria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaMDL);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaMDLExists(categoriaMDL.ID_Categoria))
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
            return View(categoriaMDL);
        }

        // GET: CategoriaCTRL/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaMDL = await _context.Categorias
                .FirstOrDefaultAsync(m => m.ID_Categoria == id);
            if (categoriaMDL == null)
            {
                return NotFound();
            }

            return View(categoriaMDL);
        }

        // POST: CategoriaCTRL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriaMDL = await _context.Categorias.FindAsync(id);
            _context.Categorias.Remove(categoriaMDL);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaMDLExists(int id)
        {
            return _context.Categorias.Any(e => e.ID_Categoria == id);
        }
    }
}
