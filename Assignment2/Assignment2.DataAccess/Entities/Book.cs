using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Assignment2.DataAccess.Entities
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        public String Title { get; set; }
        public String Type { get; set; }
        [ForeignKey("Publisher")]
        public int Pub_Id { get; set; }
        public float Price { get; set; }
        public String Advance { get; set; }
        public float Royalty { get; set; }
        public int YtdSales { get; set; }
        public String Notes { get; set; }
        public DateTime PublishedDate { get; set; }
        public List<BookAuthor> bookAuthors { get; set; }
    }
}
