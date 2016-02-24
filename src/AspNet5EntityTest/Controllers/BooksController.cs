using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using AspNet5EntityTest.Models;
using Microsoft.AspNet.Authorization;

namespace AspNet5EntityTest.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Books
        public IActionResult Index(string bookGenre, string searchString)
        {
            var genres = from b in _context.Book
                         orderby b.Genre
                         select b.Genre;

            genres = genres.Distinct();
            ViewData["bookGenre"] = new SelectList(genres);

            var books = from b in _context.Book
                        select b;

            if (searchString?.Length > 0)
            {
                books = books.Where(b => b.Title.Contains(searchString));
            }

            if (bookGenre?.Length > 0)
            {
                books = books.Where(b => b.Genre == bookGenre);
            }

            books = books.Include(b => b.Author);

            return View(books);
        }

        // GET: Books/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Book book = _context.Book.Single(m => m.BookId == id);
            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Set<Author>(), "AuthorId", "Author");
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Book.Add(book);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["AuthorId"] = new SelectList(_context.Set<Author>(), "AuthorId", "Author", book.AuthorId);
            return View(book);
        }

        // GET: Books/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Book book = _context.Book.Single(m => m.BookId == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Set<Author>(), "AuthorId", "Author", book.AuthorId);
            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Update(book);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["AuthorId"] = new SelectList(_context.Set<Author>(), "AuthorId", "Author", book.AuthorId);
            return View(book);
        }

        // GET: Books/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Book book = _context.Book.Single(m => m.BookId == id);
            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Book book = _context.Book.Single(m => m.BookId == id);
            _context.Book.Remove(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
