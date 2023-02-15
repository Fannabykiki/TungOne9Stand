using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Assignment2.DataAccess.Entities
{
    public class User

    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String Source { get; set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        [ForeignKey("Publisher")]
        public int PubId { get; set; }
        public DateTime HireDate {get; set; }
        public List<BookAuthor> bookAuthors { get; set; }

    }
}
