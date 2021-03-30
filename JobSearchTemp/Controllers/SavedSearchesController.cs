using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobSearch.Models;
using JobSearchTemp.Data;
using Microsoft.AspNetCore.Authorization;

namespace JobSearchTemp.Controllers
{
    public class SavedSearchesController : Controller
    {
        private readonly JobsDBContext _context;

        public SavedSearchesController(JobsDBContext context)
        {
            _context = context;
        }

        // GET: SavedSearches
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.SavedSearches.ToListAsync());
        }

        // GET: SavedSearches/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var savedSearch = await _context.SavedSearches
                .FirstOrDefaultAsync(m => m.SavedSearchId == id);
            if (savedSearch == null)
            {
                return NotFound();
            }

            return View(savedSearch);
        }

        // GET: SavedSearches/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: SavedSearches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("SavedSearchId")] SavedSearch savedSearch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(savedSearch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(savedSearch);
        }

        // GET: SavedSearches/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var savedSearch = await _context.SavedSearches.FindAsync(id);
            if (savedSearch == null)
            {
                return NotFound();
            }
            return View(savedSearch);
        }

        // POST: SavedSearches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("SavedSearchId")] SavedSearch savedSearch)
        {
            if (id != savedSearch.SavedSearchId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(savedSearch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SavedSearchExists(savedSearch.SavedSearchId))
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
            return View(savedSearch);
        }

        // GET: SavedSearches/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var savedSearch = await _context.SavedSearches
                .FirstOrDefaultAsync(m => m.SavedSearchId == id);
            if (savedSearch == null)
            {
                return NotFound();
            }

            return View(savedSearch);
        }

        // POST: SavedSearches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var savedSearch = await _context.SavedSearches.FindAsync(id);
            _context.SavedSearches.Remove(savedSearch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SavedSearchExists(int id)
        {
            return _context.SavedSearches.Any(e => e.SavedSearchId == id);
        }
    }
}
