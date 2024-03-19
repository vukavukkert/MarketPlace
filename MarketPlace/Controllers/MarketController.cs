using MarketDataBase.Entities;
using MarketPlace.Models.ModelInteraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace MarketPlace.Controllers
{
    public class MarketController : Controller
    {
        private readonly MarketPlaceContext Db;
        private ItemInteractions items;
        public MarketController(MarketPlaceContext dbcontext)
        {
            Db = dbcontext;
            items = new ItemInteractions(Db);
        }
        public async Task<IActionResult> Index()
        {
            return View(await items.GetAll());
        }
        //get: Market/Search%key=""
        public async Task<IActionResult> Search(string key)
        {
            try
            {
                if (key.IsNullOrEmpty()) RedirectToAction(nameof(Index));
                return View(nameof(Index), await items.GetAll(key));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return BadRequest();
            }

        }
        //get: Market/Create
        public async Task<IActionResult> Create()
        {
            var vendors = await Db.Vendors.ToListAsync();
            ViewBag.Vendors = new SelectList(vendors, "Id", "Name");
            return View();
        }
        //post: Market/Create
        [HttpPost]
        public async Task<IActionResult> Create(IFormFile photo, Item item)
        {
            try
            {
                if (photo.Length > 0)
                {
                    var fileName = Path.GetFileName(photo.FileName);
                    var serverPath = "/src/images/Uploaded/Items/";
                    var path = Path.Combine(Environment.CurrentDirectory + "/wwwroot" + serverPath, fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await photo.CopyToAsync(fileStream);
                    }

                    item.Picture = serverPath + fileName;
                }
                await items.Create(item);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return BadRequest();
            }
        }
        //get: Market/Deatails
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                var item = await items.Read(id);
                ViewBag.VendorName = await Db.Vendors.Where(x => x.Id == item.Vendor).Select(v => v.Name).FirstOrDefaultAsync();
                return View(item);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return RedirectToAction(nameof(Index));
            }

        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                var item = await items.Read(id);
                await items.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return NotFound();
            }
        }


    }
}
