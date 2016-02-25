using AspNet5EntityTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet5EntityTest.Repositories
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> ListAll();
        Author GetById(int authorId);

        void Add(Author book);
        void Update(Author book);
    }
}
