using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using AspNet5EntityTest.Models;
using Microsoft.AspNet.Authorization;
using AspNet5EntityTest.Repositories;
using System.Collections.Generic;

namespace AspNet5EntityTest.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private IBookRepository _books;
        private IAuthorRepository _authors;

        public BooksController(IBookRepository books, IAuthorRepository authors)
        {
            _books = books;
            _authors = authors;
        }

        // GET: Books
        public IActionResult Index(string bookGenre, string searchString)
        {
            IEnumerable<string> genres = _books.GetAllBookGenres();
            ViewData["bookGenre"] = new SelectList(genres);

            IEnumerable<Book> books = _books.Find(bookGenre, searchString, true);
            return View(books);
        }

        // GET: Books/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Book book = _books.GetById(id.Value, true);
            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["bookAuthor"] = new SelectList(_authors.ListAll(), "AuthorId", "FullName");
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _books.Add(book);
                return RedirectToAction("Index");
            }
            ViewData["bookAuthor"] = new SelectList(_authors.ListAll(), "AuthorId", "FullName", book.AuthorId);
            return View(book);
        }

        // GET: Books/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Book book = _books.GetById(id.Value, true);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewData["bookAuthor"] = new SelectList(_authors.ListAll(), "AuthorId", "FullName", book.AuthorId);
            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _books.Update(book);
                return RedirectToAction("Index");
            }
            ViewData["bookAuthor"] = new SelectList(_authors.ListAll(), "AuthorId", "FullName", book.AuthorId);
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

            Book book = _books.GetById(id.Value, true);

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
            Book book = _books.GetById(id, false);
            _books.Remove(book);
            return RedirectToAction("Index");
        }
    }
}
