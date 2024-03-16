using Microsoft.EntityFrameworkCore;
using MarketPlace.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Controllers
{
    public class MarketController : Controller
    {
         MarketPlaceContext db;

        public MarketController(MarketPlaceContext dbcontext)
        {
            db = dbcontext;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.Items.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Item item)
        {
            db.Items.Add(item);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
