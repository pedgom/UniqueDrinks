using System;
using System.Collections.Generic;
using System.IO;
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
                return RedirectToAction("Index");
            }

            var imagem = await _context.Imagens
                                         .Include(f => f.Bebida)
                                         .FirstOrDefaultAsync(f => f.Id == id);
            if (imagem == null)
            {
                
                return RedirectToAction("Index");
            }

            return View(imagem);
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
            if (foto.BebidaFK < 0)
            {
                // não foi escolhido uma bebida válido 
                ModelState.AddModelError("", "Não se esqueça de escolher uma bebida...");
                // devolver o controlo à View
                ViewData["BebidaFK"] = new SelectList(_context.Bebidas.OrderBy(c => c.Nome), "Id", "Nome");
                return View(foto);
            }
            string nomeImagem = "";

            if (fotoBebida == null)
            {
                // não há ficheiro
                // adicionar msg de erro
                ModelState.AddModelError("", "Adicione, por favor, a imagem da bebida");
                // devolver o controlo à View
                ViewData["BebidaFK"] = new SelectList(_context.Bebidas.OrderBy(c => c.Nome), "Id", "Nome");
                return View(foto);
            }
            else
            {
                // há ficheiro. Mas, será um ficheiro válido?
                if (fotoBebida.ContentType == "image/jpeg" || fotoBebida.ContentType == "image/png")
                {
                    // definir o novo nome da fotografia     
                    Guid g;
                    g = Guid.NewGuid();
                    nomeImagem = foto.BebidaFK + "_" + g.ToString(); 
                                                                  
                    string extensao = Path.GetExtension(fotoBebida.FileName).ToLower();
                    // agora, consigo ter o nome final do ficheiro
                    nomeImagem = nomeImagem + extensao;

                    // associar este ficheiro aos dados da Imagem da bebida
                    foto.Imagem = nomeImagem;

                    // localização do armazenamento da imagem
                    string localizacaoFicheiro = _caminho.WebRootPath;
                    nomeImagem = Path.Combine(localizacaoFicheiro, "fotos", nomeImagem);
                }
                else
                {
                    // ficheiro não é válido
                    // adicionar msg de erro
                    ModelState.AddModelError("", "Só pode escolher uma imagem para a associar à bebida");
                    // devolver o controlo à View
                    ViewData["BebidaFK"] = new SelectList(_context.Bebidas.OrderBy(c => c.Nome), "Id", "Nome");
                    return View(foto);
                }
            }


            if (ModelState.IsValid)
            {
                try
                {
                    // adicionar os dados da nova fotografia à base de dados
                    _context.Add(foto);
                    // consolidar os dados na base de dados
                    await _context.SaveChangesAsync();

                    // se cheguei aqui, tudo correu bem
                    // vou guardar, agora, no disco rígido do Servidor a imagem
                    using var stream = new FileStream(nomeImagem, FileMode.Create);
                    await fotoBebida.CopyToAsync(stream);


                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Ocorreu um erro...");

                }
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

            var imagem = await _context.Imagens.FindAsync(id);
            if (imagem == null)
            {
                return NotFound();
            }
            ViewData["BebidaFK"] = new SelectList(_context.Bebidas.OrderBy(c => c.Nome), "Id", "Nome", imagem.BebidaFK);
            HttpContext.Session.SetInt32("NumImageEdit", imagem.Id);
            return View(imagem);
        }

        // POST: Imagens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Imagem,BebidaFK")] Imagens foto)
        {
            if (id != foto.Id)
            {
                return NotFound();
            }

            var numIdFoto = HttpContext.Session.GetInt32("NumImageEdit");

            
            if (numIdFoto == null || numIdFoto != foto.Id)
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImagensExists(foto.Id))
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
            ViewData["BebidaFK"] = new SelectList(_context.Bebidas, "Id", "Id", foto.BebidaFK);
            return View(foto);
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
            try
            {
                _context.Imagens.Remove(imagens);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ImagensExists(int id)
        {
            return _context.Imagens.Any(e => e.Id == id);
        }
    }
}
