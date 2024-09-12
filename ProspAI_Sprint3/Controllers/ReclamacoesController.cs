using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProspAI_Sprint3.Data;
using ProspAI_Sprint3.Models;

namespace ProspAI_Sprint3.Controllers
{
    public class ReclamacoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReclamacoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reclamacoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Reclamacoes.Include(r => r.Funcionario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reclamacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reclamacao = await _context.Reclamacoes
                .Include(r => r.Funcionario)
                .FirstOrDefaultAsync(m => m.Id_recla == id);
            if (reclamacao == null)
            {
                return NotFound();
            }

            return View(reclamacao);
        }

        // GET: Reclamacoes/Create
        public IActionResult Create()
        {
            ViewData["Id_fun"] = new SelectList(_context.Funcionarios, "Id_fun", "Email_fun");
            return View();
        }

        // POST: Reclamacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_recla,Nm_clie,Dt_recla,Origem_recla,Solucionada_recla,Assunto_recla,Id_fun")] Reclamacao reclamacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reclamacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_fun"] = new SelectList(_context.Funcionarios, "Id_fun", "Email_fun", reclamacao.Id_fun);
            return View(reclamacao);
        }

        // GET: Reclamacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reclamacao = await _context.Reclamacoes.FindAsync(id);
            if (reclamacao == null)
            {
                return NotFound();
            }
            ViewData["Id_fun"] = new SelectList(_context.Funcionarios, "Id_fun", "Email_fun", reclamacao.Id_fun);
            return View(reclamacao);
        }

        // POST: Reclamacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_recla,Nm_clie,Dt_recla,Origem_recla,Solucionada_recla,Assunto_recla,Id_fun")] Reclamacao reclamacao)
        {
            if (id != reclamacao.Id_recla)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reclamacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReclamacaoExists(reclamacao.Id_recla))
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
            ViewData["Id_fun"] = new SelectList(_context.Funcionarios, "Id_fun", "Email_fun", reclamacao.Id_fun);
            return View(reclamacao);
        }

        // GET: Reclamacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reclamacao = await _context.Reclamacoes
                .Include(r => r.Funcionario)
                .FirstOrDefaultAsync(m => m.Id_recla == id);
            if (reclamacao == null)
            {
                return NotFound();
            }

            return View(reclamacao);
        }

        // POST: Reclamacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reclamacao = await _context.Reclamacoes.FindAsync(id);
            if (reclamacao != null)
            {
                _context.Reclamacoes.Remove(reclamacao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReclamacaoExists(int id)
        {
            return _context.Reclamacoes.Any(e => e.Id_recla == id);
        }
    }
}
