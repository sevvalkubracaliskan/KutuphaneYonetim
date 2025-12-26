using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KutuphaneYonetim.Data;
using KutuphaneYonetim.Models;

namespace KutuphaneYonetim.Controllers
{
    public class BooksController : Controller
    {
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? q)
{
    var query = _context.Books.AsQueryable();

    if (!string.IsNullOrWhiteSpace(q))
    {
        query = query.Where(b =>
            b.Title.Contains(q) ||
            b.Author.Contains(q));
    }

    var books = await query
        .OrderByDescending(b => b.Id)
        .ToListAsync();

    ViewBag.Q = q;
    return View(books);
}


        // GET: /Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (!ModelState.IsValid) return View(book);

            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Books/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();
            return View(book);
        }

        // POST: /Books/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Book book)
        {
            if (!ModelState.IsValid) return View(book);

            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Books/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();
            return View(book);
        }

        // POST: /Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}