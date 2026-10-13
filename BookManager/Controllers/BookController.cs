using BookManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Controllers
{
    public class BookController : Controller
    {
        private BookManagerDbContext _context;

        public BookController(BookManagerDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Books.OrderBy(b => b.Title).ToList());
        }

        public IActionResult Detail(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            // Id is never bound from the form; only the listed properties are updated.
            if (await TryUpdateModelAsync(book, "",
                b => b.Title, b => b.Author, b => b.Genre, b => b.YearPublished,
                b => b.NumberOfPages, b => b.IsAvailable, b => b.Description, b => b.ImagePath))
            {
                _context.SaveChanges();
                return RedirectToAction("Detail", new { id = book.Id });
            }
            return View(book);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            _context.Books.Remove(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
