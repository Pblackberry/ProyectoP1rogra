using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProyectoP1rogra.Controllers
{
    public class PremiumController : Controller
    {
        private readonly GymContext _context;
        public PremiumController(GymContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Premium()
        {
            var Premium = await _context.Membresias
            .Where(e => e.membresia == "Premium")
            .ToListAsync();
            return View(Premium);
        }
    }
}
