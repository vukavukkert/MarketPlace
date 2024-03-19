﻿using MarketDataBase.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Controllers
{
    public class AuthController : Controller
    {
        private readonly MarketPlaceContext _context;

        public AuthController(MarketPlaceContext context)
        {
            _context = context;
        }

        // GET: Auth
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(User user)
        {
            //code
            return View();
        }

        /*    // GET: Auth/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var user = await _context.Users
                    .Include(u => u.RoleNavigation)
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (user == null)
                {
                    return NotFound();
                }

                return View(user);
            }

            // GET: Auth/Create
            public IActionResult Create()
            {
                ViewData["Role"] = new SelectList(_context.Roles, "Id", "Name");
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,Name,Login,Password,Role")] User user)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["Role"] = new SelectList(_context.Roles, "Id", "Name", user.Role);
                return View(user);
            }

            // GET: Auth/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                ViewData["Role"] = new SelectList(_context.Roles, "Id", "Name", user.Role);
                return View(user);
            }

            // POST: Auth/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Login,Password,Role")] User user)
            {
                if (id != user.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(user);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!UserExists(user.Id))
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
                ViewData["Role"] = new SelectList(_context.Roles, "Id", "Name", user.Role);
                return View(user);
            }

            // GET: Auth/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var user = await _context.Users
                    .Include(u => u.RoleNavigation)
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (user == null)
                {
                    return NotFound();
                }

                return View(user);
            }

            // POST: Auth/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var user = await _context.Users.FindAsync(id);
                if (user != null)
                {
                    _context.Users.Remove(user);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool UserExists(int id)
            {
                return _context.Users.Any(e => e.Id == id);
            }*/
    }
}