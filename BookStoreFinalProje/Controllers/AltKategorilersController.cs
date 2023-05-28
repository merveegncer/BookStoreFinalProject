using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStoreFinalProje.Models;

namespace BookStoreFinalProje.Controllers
{
    public class AltKategorilersController : Controller
    {
        private readonly BookStoreDbContext _context;

        public AltKategorilersController(BookStoreDbContext context)
        {
            _context = context;
        }

        // GET: AltKategorilers
        public async Task<IActionResult> Index()
        {
            var bookStoreDbContext = _context.AltKategorilers.Include(a => a.Kategori);
            return View(await bookStoreDbContext.ToListAsync());
        }

        // GET: AltKategorilers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AltKategorilers == null)
            {
                return NotFound();
            }

            var altKategoriler = await _context.AltKategorilers
                .Include(a => a.Kategori)
                .FirstOrDefaultAsync(m => m.AltKategoriId == id);
            if (altKategoriler == null)
            {
                return NotFound();
            }

            return View(altKategoriler);
        }

        // GET: AltKategorilers/Create
        public IActionResult Create()
        {
            ViewData["KategoriId"] = new SelectList(_context.Kategorilers, "KategoriId", "KategoriAdi");
            return View();
        }

        // POST: AltKategorilers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AltKategoriId,AltKategoriAdi,KategoriId")] AltKategoriler altKategoriler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(altKategoriler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategoriId"] = new SelectList(_context.Kategorilers, "KategoriId", "KategoriId", altKategoriler.KategoriId);
            return View(altKategoriler);
        }

        // GET: AltKategorilers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AltKategorilers == null)
            {
                return NotFound();
            }

            var altKategoriler = await _context.AltKategorilers.FindAsync(id);
            if (altKategoriler == null)
            {
                return NotFound();
            }
            ViewData["KategoriId"] = new SelectList(_context.Kategorilers, "KategoriId", "KategoriId", altKategoriler.KategoriId);
            return View(altKategoriler);
        }

        // POST: AltKategorilers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AltKategoriId,AltKategoriAdi,KategoriId")] AltKategoriler altKategoriler)
        {
            if (id != altKategoriler.AltKategoriId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(altKategoriler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AltKategorilerExists(altKategoriler.AltKategoriId))
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
            ViewData["KategoriId"] = new SelectList(_context.Kategorilers, "KategoriId", "KategoriId", altKategoriler.KategoriId);
            return View(altKategoriler);
        }

        // GET: AltKategorilers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AltKategorilers == null)
            {
                return NotFound();
            }

            var altKategoriler = await _context.AltKategorilers
                .Include(a => a.Kategori)
                .FirstOrDefaultAsync(m => m.AltKategoriId == id);
            if (altKategoriler == null)
            {
                return NotFound();
            }

            return View(altKategoriler);
        }

        // POST: AltKategorilers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AltKategorilers == null)
            {
                return Problem("Entity set 'BookStoreDbContext.AltKategorilers'  is null.");
            }
            var altKategoriler = await _context.AltKategorilers.FindAsync(id);
            if (altKategoriler != null)
            {
                _context.AltKategorilers.Remove(altKategoriler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AltKategorilerExists(int id)
        {
          return (_context.AltKategorilers?.Any(e => e.AltKategoriId == id)).GetValueOrDefault();
        }
    }
}
