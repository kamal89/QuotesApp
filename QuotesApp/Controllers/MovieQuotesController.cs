using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuotesApp.Models;

namespace QuotesApp.Controllers
{
    public class MovieQuotesController : Controller
    {
        private readonly QuotesAppContext _context;

        public MovieQuotesController(QuotesAppContext context)
        {
            _context = context;
        }

        // GET: MovieQuotes
        public async Task<IActionResult> Index(string searchString)
        {
            var quotesAppContext = from m in _context.MovieQuote.Include(m => m.Movie) select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                quotesAppContext = quotesAppContext.Where(s => s.Quote.Contains(searchString));
            }
            return View(await quotesAppContext.ToListAsync());
        }

        // GET: MovieQuotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieQuote = await _context.MovieQuote
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.MovieQuoteId == id);
            if (movieQuote == null)
            {
                return NotFound();
            }

            return View(movieQuote);
        }

        // GET: MovieQuotes/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_context.Movie, "MovieId", "Title");
            return View();
        }

        // POST: MovieQuotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieQuoteId,Quote,MovieId")] MovieQuote movieQuote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieQuote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movie, "MovieId", "Title", movieQuote.MovieId);
            return View(movieQuote);
        }

        // GET: MovieQuotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieQuote = await _context.MovieQuote.FindAsync(id);
            if (movieQuote == null)
            {
                return NotFound();
            }
            ViewData["MovieId"] = new SelectList(_context.Movie, "MovieId", "Title", movieQuote.MovieId);
            return View(movieQuote);
        }

        // POST: MovieQuotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieQuoteId,Quote,MovieId")] MovieQuote movieQuote)
        {
            if (id != movieQuote.MovieQuoteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieQuote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieQuoteExists(movieQuote.MovieQuoteId))
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
            ViewData["MovieId"] = new SelectList(_context.Movie, "MovieId", "Title", movieQuote.MovieId);
            return View(movieQuote);
        }

        // GET: MovieQuotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieQuote = await _context.MovieQuote
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.MovieQuoteId == id);
            if (movieQuote == null)
            {
                return NotFound();
            }

            return View(movieQuote);
        }

        // POST: MovieQuotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieQuote = await _context.MovieQuote.FindAsync(id);
            _context.MovieQuote.Remove(movieQuote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieQuoteExists(int id)
        {
            return _context.MovieQuote.Any(e => e.MovieQuoteId == id);
        }

        // GET: MovieQuotes/Random
        public async Task<IActionResult> Random()
        {
            
            var quotesAppContext = from m in _context.MovieQuote.Include(m => m.Movie) select m;
            quotesAppContext = quotesAppContext.OrderBy(r => Guid.NewGuid()).Take(5);

            return View(await quotesAppContext.ToListAsync());

        }

    }
}
