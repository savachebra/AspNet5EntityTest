using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AspNet5EntityTest.Models
{
    public class Book
    {
        [ScaffoldColumn(false)]
        public int BookId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Range(1000, 3000)]
        public int Year { get; set; }

        [Range(1, 500)]
        public decimal Price { get; set; }

        [MaxLength(50)]
        public string Genre { get; set; }

        [ScaffoldColumn(false)]
        public int AuthorId { get; set; }

        //Navigation property
        public virtual Author Author { get; set; }
    }
}
