using MarketDataBase.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Controllers
{
    public class PointsController : Controller
    {
        private readonly MarketPlaceContext _context;

        public PointsController(MarketPlaceContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.PickupPoints.ToList());
        }
        public IActionResult Employees(int? id)
        {
            var staff = _context.Staff.Where(s => s.PickupPoint == id)
                .ToList();
            ViewBag.Point = _context.PickupPoints.FirstOrDefault(p => p.Id == id);
            return View(staff);
        }
    }
}
