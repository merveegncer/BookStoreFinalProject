﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStoreFinalProje.Models;

namespace BookStoreFinalProje.Controllers
{
    public class KitaplarsController : Controller
    {
        private readonly BookStoreDbContext _context;

        public KitaplarsController(BookStoreDbContext context)
        {
            _context = context;
        }

        // GET: Kitaplars
        public async Task<IActionResult> Index()
        {
            var bookStoreDbContext = _context.Kitaplars.Include(k => k.AltKategori);
            return View(await bookStoreDbContext.ToListAsync());
        }

        // GET: Kitaplars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Kitaplars == null)
            {
                return NotFound();
            }

            var kitaplar = await _context.Kitaplars
                .Include(k => k.AltKategori)
                .FirstOrDefaultAsync(m => m.KitapId == id);
            if (kitaplar == null)
            {
                return NotFound();
            }

            return View(kitaplar);
        }

        // GET: Kitaplars/Create
        public IActionResult Create()
        {
            ViewData["AltKategoriId"] = new SelectList(_context.AltKategorilers, "AltKategoriId", "AltKategoriId");
            return View();
        }

        // POST: Kitaplars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KitapId,KitapAdi,AltKategoriId,Fiyat,YayinTarihi,KitapAciklama,KitapFoto,YazarAdi,StokMiktari")] Kitaplar kitaplar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kitaplar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AltKategoriId"] = new SelectList(_context.AltKategorilers, "AltKategoriId", "AltKategoriId", kitaplar.AltKategoriId);
            return View(kitaplar);
        }

        // GET: Kitaplars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Kitaplars == null)
            {
                return NotFound();
            }

            var kitaplar = await _context.Kitaplars.FindAsync(id);
            if (kitaplar == null)
            {
                return NotFound();
            }
            ViewData["AltKategoriId"] = new SelectList(_context.AltKategorilers, "AltKategoriId", "AltKategoriId", kitaplar.AltKategoriId);
            return View(kitaplar);
        }

        // POST: Kitaplars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KitapId,KitapAdi,AltKategoriId,Fiyat,YayinTarihi,KitapAciklama,KitapFoto,YazarAdi,StokMiktari")] Kitaplar kitaplar)
        {
            if (id != kitaplar.KitapId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kitaplar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KitaplarExists(kitaplar.KitapId))
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
            ViewData["AltKategoriId"] = new SelectList(_context.AltKategorilers, "AltKategoriId", "AltKategoriId", kitaplar.AltKategoriId);
            return View(kitaplar);
        }

        // GET: Kitaplars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Kitaplars == null)
            {
                return NotFound();
            }

            var kitaplar = await _context.Kitaplars
                .Include(k => k.AltKategori)
                .FirstOrDefaultAsync(m => m.KitapId == id);
            if (kitaplar == null)
            {
                return NotFound();
            }

            return View(kitaplar);
        }

        // POST: Kitaplars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Kitaplars == null)
            {
                return Problem("Entity set 'BookStoreDbContext.Kitaplars'  is null.");
            }
            var kitaplar = await _context.Kitaplars.FindAsync(id);
            if (kitaplar != null)
            {
                _context.Kitaplars.Remove(kitaplar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KitaplarExists(int id)
        {
          return (_context.Kitaplars?.Any(e => e.KitapId == id)).GetValueOrDefault();
        }
    }
}
