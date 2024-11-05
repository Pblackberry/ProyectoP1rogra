using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProyectoP1rogra.Controllers
{
    public class EstandarController : Controller
    {
        private readonly GymContext _context;
        public EstandarController(GymContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Estandar()
        {
            var Estandar = await _context.Membresias
            .Where(e => e.membresia == "Estandar")
            .ToListAsync();
            return View(Estandar);
        }
    }
}
