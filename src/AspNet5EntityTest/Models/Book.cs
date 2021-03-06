﻿using System;
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
        [StringLength(200, MinimumLength = 3)]
        public string Title { get; set; }

        [Range(1000, 3000)]
        public int Year { get; set; }

        [Range(1, 500)]
        public decimal Price { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(30)]
        public string Genre { get; set; }

        public int AuthorId { get; set; }

        //Navigation property
        public virtual Author Author { get; set; }
    }
}
