using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoP1rogra.Models;

namespace ProyectoP1rogra.Controllers
{
    public class MembresiasController : Controller
    {
        private readonly GymContext _context;

        public MembresiasController(GymContext context)
        {
            _context = context;
        }

        // GET: Membresias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Membresias.ToListAsync());
        }

        // GET: Membresias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membresias = await _context.Membresias
                .FirstOrDefaultAsync(m => m.IDcliente == id);
            if (membresias == null)
            {
                return NotFound();
            }

            return View(membresias);
        }

        // GET: Membresias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Membresias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDcliente,cedula,nombre,membresia,caducidad")] Membresias membresias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membresias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(membresias);
        }

        // GET: Membresias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membresias = await _context.Membresias.FindAsync(id);
            if (membresias == null)
            {
                return NotFound();
            }
            return View(membresias);
        }

        // POST: Membresias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDcliente,cedula,nombre,membresia,caducidad")] Membresias membresias)
        {
            if (id != membresias.IDcliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membresias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembresiasExists(membresias.IDcliente))
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
            return View(membresias);
        }

        // GET: Membresias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membresias = await _context.Membresias
                .FirstOrDefaultAsync(m => m.IDcliente == id);
            if (membresias == null)
            {
                return NotFound();
            }

            return View(membresias);
        }

        // POST: Membresias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var membresias = await _context.Membresias.FindAsync(id);
            if (membresias != null)
            {
                _context.Membresias.Remove(membresias);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembresiasExists(int id)
        {
            return _context.Membresias.Any(e => e.IDcliente == id);
        }
    }
}
