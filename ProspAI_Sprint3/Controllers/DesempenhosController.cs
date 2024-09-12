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
    public class DesempenhosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DesempenhosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Desempenhos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Desempenhos.Include(d => d.Funcionario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Desempenhos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desempenho = await _context.Desempenhos
                .Include(d => d.Funcionario)
                .FirstOrDefaultAsync(m => m.Id_desem == id);
            if (desempenho == null)
            {
                return NotFound();
            }

            return View(desempenho);
        }

        // GET: Desempenhos/Create
        public IActionResult Create()
        {
            ViewData["Id_fun"] = new SelectList(_context.Funcionarios, "Id_fun", "Email_fun");
            return View();
        }

        // POST: Desempenhos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_desem,Mes_desem,Reclamacoes_resp,Reclamacoes_solu,Id_fun")] Desempenho desempenho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(desempenho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_fun"] = new SelectList(_context.Funcionarios, "Id_fun", "Email_fun", desempenho.Id_fun);
            return View(desempenho);
        }

        // GET: Desempenhos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desempenho = await _context.Desempenhos.FindAsync(id);
            if (desempenho == null)
            {
                return NotFound();
            }
            ViewData["Id_fun"] = new SelectList(_context.Funcionarios, "Id_fun", "Email_fun", desempenho.Id_fun);
            return View(desempenho);
        }

        // POST: Desempenhos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_desem,Mes_desem,Reclamacoes_resp,Reclamacoes_solu,Id_fun")] Desempenho desempenho)
        {
            if (id != desempenho.Id_desem)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(desempenho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DesempenhoExists(desempenho.Id_desem))
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
            ViewData["Id_fun"] = new SelectList(_context.Funcionarios, "Id_fun", "Email_fun", desempenho.Id_fun);
            return View(desempenho);
        }

        // GET: Desempenhos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desempenho = await _context.Desempenhos
                .Include(d => d.Funcionario)
                .FirstOrDefaultAsync(m => m.Id_desem == id);
            if (desempenho == null)
            {
                return NotFound();
            }

            return View(desempenho);
        }

        // POST: Desempenhos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var desempenho = await _context.Desempenhos.FindAsync(id);
            if (desempenho != null)
            {
                _context.Desempenhos.Remove(desempenho);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DesempenhoExists(int id)
        {
            return _context.Desempenhos.Any(e => e.Id_desem == id);
        }
    }
}
