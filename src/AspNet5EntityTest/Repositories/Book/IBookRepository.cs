using AspNet5EntityTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet5EntityTest.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> ListAll();
        Book GetById(int bookId, bool includeAuthor);
        IEnumerable<string> GetAllBookGenres();
        IEnumerable<Book> Find(string bookGenre, string searchString, bool includeAuthors);

        void Add(Book book);
        void Update(Book book);
        void Remove(Book book);
    }
}
