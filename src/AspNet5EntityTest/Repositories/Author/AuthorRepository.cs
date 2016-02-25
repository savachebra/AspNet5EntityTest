using AspNet5EntityTest.Models;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet5EntityTest.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Author> ListAll()
        {
            return _context.Author;
        }

        public Author GetById(int authorId)
        {
            IQueryable<Author> authors = from a in _context.Author
                                         select a;

            return authors.Single(a => a.AuthorId == authorId);
        }

        public void Add(Author author)
        {
            _context.Author.Add(author);
            _context.SaveChanges();
        }

        public void Update(Author author)
        {
            _context.Author.Update(author);
            _context.SaveChanges();
        }
    }
}
