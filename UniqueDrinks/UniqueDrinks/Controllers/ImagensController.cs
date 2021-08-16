using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniqueDrinks.Data;
using UniqueDrinks.Models;

namespace UniqueDrinks.Controllers
{
    public class ImagensController : Controller
    {
        private readonly DrinksDB _context;

        private readonly IWebHostEnvironment _caminho;

        public ImagensController(
            DrinksDB context,
            IWebHostEnvironment caminho
            )
        { 
            _context = context;
            _caminho = caminho;
        }

        // GET: Imagens
        public async Task<IActionResult> Index()
        {
            var imagens = _context.Imagens.Include(i => i.Bebida);
            return View(await imagens.ToListAsync());
        }

        // GET: Imagens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imagens = await _context.Imagens
                .Include(i => i.Bebida)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imagens == null)
            {
                return NotFound();
            }

            return View(imagens);
        }

        // GET: Imagens/Create
        public IActionResult Create()
        {
            ViewData["BebidaFK"] = new SelectList(_context.Bebidas.OrderBy(c => c.Nome), "Id", "Nome");
            return View();
        }

        // POST: Imagens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BebidaFK")] Imagens foto, IFormFile fotoBebida)
        {
            // avaliar se  o utilizador escolheu uma opção válida na dropdown da Bebida
            if (foto.BebidaFK > 0)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Add(foto);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Ocorreu um erro...");

                    }
                }
            }
            else
            {
                // não foi escolhido uma bebida válida 
                ModelState.AddModelError("", "Não se esqueça de escolher uma bebida...");
            }

            ViewData["BebidaFK"] = new SelectList(_context.Bebidas.OrderBy(c => c.Nome), "Id", "Nome", foto.BebidaFK);

            return View(foto);
        }

        // GET: Imagens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imagens = await _context.Imagens.FindAsync(id);
            if (imagens == null)
            {
                return NotFound();
            }
            ViewData["BebidaFK"] = new SelectList(_context.Bebidas.OrderBy(c => c.Nome), "Id", "Nome", imagens.BebidaFK);
            return View(imagens);
        }

        // POST: Imagens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Imagem,BebidaFK")] Imagens imagens)
        {
            if (id != imagens.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imagens);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImagensExists(imagens.Id))
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
            ViewData["BebidaFK"] = new SelectList(_context.Bebidas, "Id", "Id", imagens.BebidaFK);
            return View(imagens);
        }

        // GET: Imagens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imagens = await _context.Imagens
                .Include(i => i.Bebida)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imagens == null)
            {
                return NotFound();
            }

            return View(imagens);
        }

        // POST: Imagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imagens = await _context.Imagens.FindAsync(id);
            _context.Imagens.Remove(imagens);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImagensExists(int id)
        {
            return _context.Imagens.Any(e => e.Id == id);
        }
    }
}
