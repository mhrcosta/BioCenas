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
    public class ProdutoCTRL : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdutoCTRL(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProdutoCTRL
        public async Task<IActionResult> Index()
        {
            return View(await _context.Produtos.ToListAsync());
        }

        // GET: ProdutoCTRL/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoMDL = await _context.Produtos
                .FirstOrDefaultAsync(m => m.ID_Produto == id);
            if (produtoMDL == null)
            {
                return NotFound();
            }

            return View(produtoMDL);
        }

        // GET: ProdutoCTRL/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProdutoCTRL/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Produto,DesignacaoProduto,DescricaoProduto,QTDisponivel,EstadoProduto,PrecoProduto")] ProdutoMDL produtoMDL)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produtoMDL);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produtoMDL);
        }

        // GET: ProdutoCTRL/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoMDL = await _context.Produtos.FindAsync(id);
            if (produtoMDL == null)
            {
                return NotFound();
            }
            return View(produtoMDL);
        }

        // POST: ProdutoCTRL/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Produto,DesignacaoProduto,DescricaoProduto,QTDisponivel,EstadoProduto,PrecoProduto")] ProdutoMDL produtoMDL)
        {
            if (id != produtoMDL.ID_Produto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produtoMDL);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoMDLExists(produtoMDL.ID_Produto))
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
            return View(produtoMDL);
        }

        // GET: ProdutoCTRL/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoMDL = await _context.Produtos
                .FirstOrDefaultAsync(m => m.ID_Produto == id);
            if (produtoMDL == null)
            {
                return NotFound();
            }

            return View(produtoMDL);
        }

        // POST: ProdutoCTRL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produtoMDL = await _context.Produtos.FindAsync(id);
            _context.Produtos.Remove(produtoMDL);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoMDLExists(int id)
        {
            return _context.Produtos.Any(e => e.ID_Produto == id);
        }
    }
}
