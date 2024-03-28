using MarketDataBase.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Controllers
{
    public class PointsController : Controller
    {
        private readonly MarketPlaceContext _context;

        public PointsController(MarketPlaceContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.PickupPoints.ToListAsync());
        }
        public async Task<IActionResult> Employees(int? id)
        {
            var staff = await _context.Staff.Where(s => s.PickupPoint == id)
                .ToListAsync();
            ViewBag.Point = await _context.PickupPoints.FirstOrDefaultAsync(p => p.Id == id);
            return View(staff);
        }
    }
}
