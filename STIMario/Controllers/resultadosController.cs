using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using STIMario.Models;

namespace STIMario.Controllers
{
    public class resultadosController : Controller
    {
        private readonly STIMarioContext _context;

        public resultadosController(STIMarioContext context)
        {
            _context = context;
        }

        // GET: resultados
        public async Task<IActionResult> Index()
        {
            return View(await _context.Resultados.ToListAsync());
        }

        // GET: resultados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultados = await _context.Resultados
                .SingleOrDefaultAsync(m => m.IDresultados == id);
            if (resultados == null)
            {
                return NotFound();
            }

            return View(resultados);
        }

        // GET: resultados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: resultados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDresultados,RespuestasCorrectas,RespuestasIncorrectas")] Resultados resultados)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resultados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resultados);
        }

        // GET: resultados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultados = await _context.Resultados.SingleOrDefaultAsync(m => m.IDresultados == id);
            if (resultados == null)
            {
                return NotFound();
            }
            return View(resultados);
        }

        // POST: resultados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDresultados,RespuestasCorrectas,RespuestasIncorrectas")] Resultados resultados)
        {
            if (id != resultados.IDresultados)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resultados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!resultadosExists(resultados.IDresultados))
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
            return View(resultados);
        }

        // GET: resultados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultados = await _context.Resultados
                .SingleOrDefaultAsync(m => m.IDresultados == id);
            if (resultados == null)
            {
                return NotFound();
            }

            return View(resultados);
        }

        // POST: resultados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resultados = await _context.Resultados.SingleOrDefaultAsync(m => m.IDresultados == id);
            _context.Resultados.Remove(resultados);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool resultadosExists(int id)
        {
            return _context.Resultados.Any(e => e.IDresultados == id);
        }
    }
}
