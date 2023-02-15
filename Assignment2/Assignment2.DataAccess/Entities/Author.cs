using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Assignment2.DataAccess.Entities
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        public String LastName { get; set; }
        public String FirstName { get; set; }
        public String Phone { get; set; }
        public String Address { get; set; }
        public String  City { get; set; }
        public String State { get; set; }
        public int Zip { get; set; }
        public String Email { get; set; }
        public List<BookAuthor> BookAuthorList { get; set; }
    }
}
