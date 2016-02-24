using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;

namespace AspNet5EntityTest.Models
{
    public static class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            context.Database.Migrate();

            if (!context.Book.Any())
            {
                var dostojevskij = context.Author.Add(
                    new Author { LastName = "Dostojevskij", FirstMidName = "Fiodor" }).Entity;
                var remarque = context.Author.Add(
                    new Author { LastName = "Remarque", FirstMidName = "Erik Maria" }).Entity;

                context.Book.AddRange(
                    new Book
                    {
                        Title = "Idiot, The",
                        Year = 1866,
                        Author = dostojevskij,
                        Genre = "Novel",
                        Price = 12.55M
                    },
                    new Book
                    {
                        Title = "Brothers Karamazovs",
                        Year = 1870,
                        Author = dostojevskij,
                        Genre = "Novel",
                        Price = 15.15M
                    },
                    new Book
                    {
                        Title = "Three friends",
                        Year = 1950,
                        Author = remarque,
                        Genre = "Novel",
                        Price = 10.20M
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
