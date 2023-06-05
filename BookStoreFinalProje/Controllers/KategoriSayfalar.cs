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
    public class KategoriSayfalarController : Controller
    {
        private readonly BookStoreDbContext _context;

        public KategoriSayfalarController(BookStoreDbContext context)
        {
            _context = context;
        }

        // GET: KategoriSayfalar
       


        public async Task<IActionResult> Roman(int? AltKategoriId, string SearchString)
        {

            IQueryable<Kitaplar> kitaplarQuery = _context.Kitaplars.Include(k => k.AltKategori).Where(k => k.AltKategori.KategoriId == 1);
            ViewBag.AltKategoriId = new SelectList(_context.AltKategorilers.Where(a => a.KategoriId == 1), "AltKategoriId", "AltKategoriAdi");

            if (AltKategoriId.HasValue)
            {
                kitaplarQuery = kitaplarQuery.Where(k => k.AltKategoriId == AltKategoriId.Value);
            }

            if (!String.IsNullOrEmpty(SearchString))
            {
                kitaplarQuery = kitaplarQuery.Where(k => k.KitapAdi.ToUpper().Contains(SearchString.ToUpper())
                                                    || k.YazarAdi.ToUpper().Contains(SearchString.ToUpper()));
            }

            var kitaplar = await kitaplarQuery.ToListAsync();

            return View(kitaplar);
        }




        public async Task<IActionResult> Egitim(int? AltKategoriId, string SearchString)
        {

            IQueryable<Kitaplar> kitaplarQuery = _context.Kitaplars.Include(k => k.AltKategori).Where(k => k.AltKategori.KategoriId == 2);
            ViewBag.AltKategoriId = new SelectList(_context.AltKategorilers.Where(a => a.KategoriId == 2), "AltKategoriId", "AltKategoriAdi");

            if (AltKategoriId.HasValue)
            {
                kitaplarQuery = kitaplarQuery.Where(k => k.AltKategoriId == AltKategoriId.Value);
            }

            if (!String.IsNullOrEmpty(SearchString))
            {
                kitaplarQuery = kitaplarQuery.Where(k => k.KitapAdi.ToUpper().Contains(SearchString.ToUpper())
                                                    || k.YazarAdi.ToUpper().Contains(SearchString.ToUpper()));
            }

            var kitaplar = await kitaplarQuery.ToListAsync();

            return View(kitaplar);
        }




        public async Task<IActionResult> KisiselGelisim(int? AltKategoriId, string SearchString)
        {

            IQueryable<Kitaplar> kitaplarQuery = _context.Kitaplars.Include(k => k.AltKategori).Where(k => k.AltKategori.KategoriId == 3);
            ViewBag.AltKategoriId = new SelectList(_context.AltKategorilers.Where(a => a.KategoriId == 3), "AltKategoriId", "AltKategoriAdi");

            if (AltKategoriId.HasValue)
            {
                kitaplarQuery = kitaplarQuery.Where(k => k.AltKategoriId == AltKategoriId.Value);
            }

            if (!String.IsNullOrEmpty(SearchString))
            {
                kitaplarQuery = kitaplarQuery.Where(k => k.KitapAdi.ToUpper().Contains(SearchString.ToUpper())
                                                    || k.YazarAdi.ToUpper().Contains(SearchString.ToUpper()));
            }

            var kitaplar = await kitaplarQuery.ToListAsync();

            return View(kitaplar);
        }


        public async Task<IActionResult> Tarih(int? AltKategoriId, string SearchString)
        {

            IQueryable<Kitaplar> kitaplarQuery = _context.Kitaplars.Include(k => k.AltKategori).Where(k => k.AltKategori.KategoriId == 4);
            ViewBag.AltKategoriId = new SelectList(_context.AltKategorilers.Where(a => a.KategoriId == 4), "AltKategoriId", "AltKategoriAdi");

            if (AltKategoriId.HasValue)
            {
                kitaplarQuery = kitaplarQuery.Where(k => k.AltKategoriId == AltKategoriId.Value);
            }

            if (!String.IsNullOrEmpty(SearchString))
            {
                kitaplarQuery = kitaplarQuery.Where(k => k.KitapAdi.ToUpper().Contains(SearchString.ToUpper())
                                                    || k.YazarAdi.ToUpper().Contains(SearchString.ToUpper()));
            }

            var kitaplar = await kitaplarQuery.ToListAsync();

            return View(kitaplar);
        }


        public async Task<IActionResult> Din(int? AltKategoriId, string SearchString)
        {

            IQueryable<Kitaplar> kitaplarQuery = _context.Kitaplars.Include(k => k.AltKategori).Where(k => k.AltKategori.KategoriId == 5);
            ViewBag.AltKategoriId = new SelectList(_context.AltKategorilers.Where(a => a.KategoriId == 5), "AltKategoriId", "AltKategoriAdi");

            if (AltKategoriId.HasValue)
            {
                kitaplarQuery = kitaplarQuery.Where(k => k.AltKategoriId == AltKategoriId.Value);
            }

            if (!String.IsNullOrEmpty(SearchString))
            {
                kitaplarQuery = kitaplarQuery.Where(k => k.KitapAdi.ToUpper().Contains(SearchString.ToUpper())
                                                    || k.YazarAdi.ToUpper().Contains(SearchString.ToUpper()));
            }

            var kitaplar = await kitaplarQuery.ToListAsync();

            return View(kitaplar);
        }



        public async Task<IActionResult> Felsefe(int? AltKategoriId, string SearchString)
        {

            IQueryable<Kitaplar> kitaplarQuery = _context.Kitaplars.Include(k => k.AltKategori).Where(k => k.AltKategori.KategoriId == 6);
            ViewBag.AltKategoriId = new SelectList(_context.AltKategorilers.Where(a => a.KategoriId == 6), "AltKategoriId", "AltKategoriAdi");

            if (AltKategoriId.HasValue)
            {
                kitaplarQuery = kitaplarQuery.Where(k => k.AltKategoriId == AltKategoriId.Value);
            }

            if (!String.IsNullOrEmpty(SearchString))
            {
                kitaplarQuery = kitaplarQuery.Where(k => k.KitapAdi.ToUpper().Contains(SearchString.ToUpper())
                                                    || k.YazarAdi.ToUpper().Contains(SearchString.ToUpper()));
            }

            var kitaplar = await kitaplarQuery.ToListAsync();

            return View(kitaplar);
        }

        public async Task<IActionResult> BilimTeknoloji(int? AltKategoriId, string SearchString)
        {

            IQueryable<Kitaplar> kitaplarQuery = _context.Kitaplars.Include(k => k.AltKategori).Where(k => k.AltKategori.KategoriId == 7);
            ViewBag.AltKategoriId = new SelectList(_context.AltKategorilers.Where(a => a.KategoriId == 7), "AltKategoriId", "AltKategoriAdi");

            if (AltKategoriId.HasValue)
            {
                kitaplarQuery = kitaplarQuery.Where(k => k.AltKategoriId == AltKategoriId.Value);
            }

            if (!String.IsNullOrEmpty(SearchString))
            {
                kitaplarQuery = kitaplarQuery.Where(k => k.KitapAdi.ToUpper().Contains(SearchString.ToUpper())
                                                    || k.YazarAdi.ToUpper().Contains(SearchString.ToUpper()));
            }

            var kitaplar = await kitaplarQuery.ToListAsync();

            return View(kitaplar);
        }

        public async Task<IActionResult> RomanDetails(int? id)
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





        public async Task<IActionResult> Index()
        {
            return _context.Kategorilers != null ?
                        View(await _context.Kategorilers.ToListAsync()) :
                        Problem("Entity set 'DbKitapTakipContext.Kategorilers'  is null.");
        }


























    }
}
