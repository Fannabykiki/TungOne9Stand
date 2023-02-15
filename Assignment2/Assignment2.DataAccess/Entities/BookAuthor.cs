using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.DataAccess.Entities
{
    public class BookAuthor
    {

        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public String AuthorOrder { get; set; }
        public float RoyalityPercentage { get; set; }
    }
}
