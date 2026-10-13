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
            return View(_context.Books);
        }

        public IActionResult Detail(int Id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == Id);
            return View(book);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
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
    }
}
