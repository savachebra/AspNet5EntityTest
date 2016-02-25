using AspNet5EntityTest.Models;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet5EntityTest.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> ListAll()
        {
            return _context.Book;
        }

        public IEnumerable<string> GetAllBookGenres()
        {
            IQueryable<string> genres = from b in _context.Book
                                        orderby b.Genre
                                        select b.Genre;

            return genres.Distinct();
        }

        public IEnumerable<Book> Find(string bookGenre, string searchString, bool includeAuthors)
        {
            IQueryable<Book> books = from b in _context.Book
                                     select b;

            if (searchString?.Length > 0)
                books = books.Where(b => b.Title.Contains(searchString));

            if (bookGenre?.Length > 0)
                books = books.Where(b => b.Genre == bookGenre);

            if (includeAuthors)
                books = books.Include(b => b.Author);

            return books;
        }

        public Book GetById(int bookId, bool includeAuthor)
        {
            IQueryable<Book> books = from b in _context.Book
                                     select b;

            if (includeAuthor)
                books = books.Include(b => b.Author);

            return books.Single(b => b.BookId == bookId);
        }

        public void Add(Book book)
        {
            _context.Book.Add(book);
            _context.SaveChanges();
        }

        public void Update(Book book)
        {
            _context.Book.Update(book);
            _context.SaveChanges();
        }

        public void Remove(Book book)
        {
            _context.Book.Remove(book);
            _context.SaveChanges();
        }
    }
}
