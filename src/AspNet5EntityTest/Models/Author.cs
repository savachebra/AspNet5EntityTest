using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNet5EntityTest.Models
{
    public class Author
    {
        [ScaffoldColumn(false)]
        public int AuthorId { get; set; }

        [Required]
        [Display(Name ="Last name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "First name")]
        [StringLength(50)]
        public string FirstMidName { get; set; }

        [NotMapped]
        public string FullName => $"{FirstMidName} {LastName}";

        [StringLength(30)]
        public string Country { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
