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
    public class InicioSesionsController : Controller 
    {
        private readonly GymContext _context;

        public InicioSesionsController(GymContext context)
        {
            _context = context;
        }

        // GET: InicioSesions
        public async Task<IActionResult> Index()
        {
            return View(await _context.InicioSesion.ToListAsync());
        }

        // GET: InicioSesions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inicioSesion = await _context.InicioSesion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inicioSesion == null)
            {
                return NotFound();
            }

            return View(inicioSesion);
        }

        // GET: InicioSesions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InicioSesions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Correo,Contrasena")] InicioSesion inicioSesion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inicioSesion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inicioSesion);
        }

        // GET: InicioSesions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inicioSesion = await _context.InicioSesion.FindAsync(id);
            if (inicioSesion == null)
            {
                return NotFound();
            }
            return View(inicioSesion);
        }

        // POST: InicioSesions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Correo,Contrasena")] InicioSesion inicioSesion)
        {
            if (id != inicioSesion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inicioSesion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InicioSesionExists(inicioSesion.Id))
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
            return View(inicioSesion);
        }

        // GET: InicioSesions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inicioSesion = await _context.InicioSesion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inicioSesion == null)
            {
                return NotFound();
            }

            return View(inicioSesion);
        }

        // POST: InicioSesions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inicioSesion = await _context.InicioSesion.FindAsync(id);
            if (inicioSesion != null)
            {
                _context.InicioSesion.Remove(inicioSesion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InicioSesionExists(int id)
        {
            return _context.InicioSesion.Any(e => e.Id == id);
        }

        // GET: InicioSesions/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: InicioSesions/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string correo, string contrasena)
        {
            var usuario = await _context.InicioSesion
                .FirstOrDefaultAsync(u => u.Correo == correo && u.Contrasena == contrasena);

            if (usuario != null)
            {

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "El correo o contraseña están incorrectos";
            return View();
        }

        // GET: InicioSesions/Registro
        public IActionResult Registro()
        {
            return View();
        }

        // POST: InicioSesions/Registro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registro([Bind("Id,Correo,Contrasena")] InicioSesion inicioSesion)
        {

            var usuarioExistente = await _context.InicioSesion
                .FirstOrDefaultAsync(u => u.Correo == inicioSesion.Correo);

            if (usuarioExistente != null)
            {
                ViewBag.Error = "El correo ya está registrado";
                return View(inicioSesion);
            }


            if (ModelState.IsValid)
            {
                _context.Add(inicioSesion);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login");
            }

            return View(inicioSesion);
        }
    }
}
