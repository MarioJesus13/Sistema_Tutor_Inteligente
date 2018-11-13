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
    public class ejerciciosController : Controller
    {
        private readonly STIMarioContext _context;

        public ejerciciosController(STIMarioContext context)
        {
            _context = context;
        }

        // GET: ejercicios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ejercicios.ToListAsync());
        }

        // GET: ejercicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ejercicios = await _context.Ejercicios
                .SingleOrDefaultAsync(m => m.IDejercicio == id);
            if (ejercicios == null)
            {
                return NotFound();
            }

            return View(ejercicios);
        }

        // GET: ejercicios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ejercicios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDejercicio,NombreEjercicio,Puntaje")] Ejercicios ejercicios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ejercicios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ejercicios);
        }

        // GET: ejercicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ejercicios = await _context.Ejercicios.SingleOrDefaultAsync(m => m.IDejercicio == id);
            if (ejercicios == null)
            {
                return NotFound();
            }
            return View(ejercicios);
        }

        // POST: ejercicios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDejercicio,NombreEjercicio,Puntaje")] Ejercicios ejercicios)
        {
            if (id != ejercicios.IDejercicio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ejercicios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ejerciciosExists(ejercicios.IDejercicio))
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
            return View(ejercicios);
        }

        // GET: ejercicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ejercicios = await _context.Ejercicios
                .SingleOrDefaultAsync(m => m.IDejercicio == id);
            if (ejercicios == null)
            {
                return NotFound();
            }

            return View(ejercicios);
        }

        // POST: ejercicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ejercicios = await _context.Ejercicios.SingleOrDefaultAsync(m => m.IDejercicio == id);
            _context.Ejercicios.Remove(ejercicios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ejerciciosExists(int id)
        {
            return _context.Ejercicios.Any(e => e.IDejercicio == id);
        }
    }
}
