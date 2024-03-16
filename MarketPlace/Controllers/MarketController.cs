using MarketDataBase.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace MarketPlace.Controllers
{
    public class MarketController : Controller
    {
        private readonly MarketPlaceContext Db;
        public MarketController(MarketPlaceContext dbcontext)
        {
            Db = dbcontext;
        }
        public async Task<IActionResult> Index()
        {

            return View(await Db.Items.ToListAsync());
        }

        public async Task<IActionResult> Search(string key)
        {
            if (key.IsNullOrEmpty()) RedirectToAction(nameof(Index));
            var items = await Db.Items.Where(x => x.Name.Contains(key)).ToListAsync();
            return View(nameof(Index), items);
        }
        //get: Market/Create
        public async Task<IActionResult> Create()
        {
            var vendors = await Db.Vendors.ToListAsync();
            ViewBag.Vendors = new SelectList(vendors, "Id", "Name");
            return View();
        }
        //post: Market/Create
        /*[HttpPost]
        public async Task<IActionResult> Create()
        {
            var vendors = await Db.Vendors.ToListAsync();
            ViewBag.Vendors = new SelectList(vendors, "Id", "Name");
            return View();
        }*/
        //get: Market/Deatails
        public async Task<IActionResult> Details(int? id)
        {
            var item = await Db.Items.FirstOrDefaultAsync(x => x.Id == id);
            if (item != null)
            {
                ViewBag.VendorName = await Db.Vendors.Where(x => x.Id == item.Vendor).Select(v => v.Name).FirstOrDefaultAsync();
                return View(item);
            }
            else
            {
                return RedirectToAction(nameof(Index));

            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await Db.Items.FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            var orders = await Db.Orders.Where(x => x.Item == item.Id).ToListAsync();
            if (!orders.IsNullOrEmpty())
            {
                foreach (var order in orders)
                {
                    var points = await Db.PickupPointOrders.Where(x => x.Order == order.Id).ToListAsync();
                    foreach (var point in points)
                    {
                        Db.PickupPointOrders.Remove(point);
                    }
                    Db.Orders.Remove(order);

                }
            }
            await Db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
