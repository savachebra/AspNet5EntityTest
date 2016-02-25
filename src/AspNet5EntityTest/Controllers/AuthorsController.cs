using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using AspNet5EntityTest.Models;
using Microsoft.AspNet.Authorization;
using AspNet5EntityTest.Repositories;

namespace AspNet5EntityTest.Controllers
{
    [Authorize]
    public class AuthorsController : Controller
    {
        private IAuthorRepository _authors;

        public AuthorsController(IAuthorRepository authors)
        {
            _authors = authors;    
        }

        // GET: Authors
        public IActionResult Index()
        {
            return View(_authors.ListAll());
        }

        // GET: Authors/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Author author = _authors.GetById(id.Value);
            if (author == null)
            {
                return HttpNotFound();
            }

            return View(author);
        }

        // GET: Authors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                _authors.Add(author);
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: Authors/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Author author = _authors.GetById(id.Value);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                _authors.Update(author);
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Author author = _authors.GetById(id.Value);
            if (author == null)
            {
                return HttpNotFound();
            }

            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Author author = _authors.GetById(id);
            _authors.Remove(author);
            return RedirectToAction("Index");
        }
    }
}
