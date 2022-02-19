using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InternationalBakers.Data;
using InternationalBakers.Models;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

using Microsoft.AspNetCore.Http;
using System.IO;
using Azure.Storage.Blobs;

namespace InternationalBakers.Controllers
{
    public class CookiesController : Controller
    {
        private readonly ibdbContext _context;
        private readonly IDistributedCache _cache;

        public CookiesController(ibdbContext context, IDistributedCache cache)
        {
            _context = context;
            _cache = cache;
        }

        // GET: Cookies
        public async Task<IActionResult> Index()
        {
            List<Cookies> cookies;
            var cachedCookies = _cache.GetString("cookieList");

            if (!string.IsNullOrEmpty(cachedCookies))
            {
                cookies = JsonConvert.DeserializeObject<List<Cookies>>(cachedCookies);
            }
            else
            {
                cookies = _context.Cookies.ToList();
            _cache.SetString("cookieList", JsonConvert.SerializeObject(cookies));
        }

            return View(cookies);
        }

        // GET: Cookies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cookies = await _context.Cookies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cookies == null)
            {
                return NotFound();
            }

            return View(cookies);
        }

        // GET: Cookies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cookies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ImageUrl,Price")] Cookies cookies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cookies);
                await _context.SaveChangesAsync();
                _cache.SetString("cookies", JsonConvert.SerializeObject(_context.Cookies.ToList()));
                return RedirectToAction(nameof(Index));
            }

            return View(cookies);
        }

        // GET: Cookies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cookies = await _context.Cookies.FindAsync(id);
            if (cookies == null)
            {
                return NotFound();
            }
            return View(cookies);
        }

        // POST: Cookies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ImageUrl,Price")] Cookies cookies)
        {
            if (id != cookies.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cookies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CookiesExists(cookies.Id))
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
            return View(cookies);
        }

        // GET: Cookies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cookies = await _context.Cookies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cookies == null)
            {
                return NotFound();
            }

            return View(cookies);
        }

        // POST: Cookies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cookies = await _context.Cookies.FindAsync(id);
            _context.Cookies.Remove(cookies);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CookiesExists(int id)
        {
            return _context.Cookies.Any(e => e.Id == id);
        }

    }
}
