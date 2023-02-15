using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Assignment2.DataAccess.Entities
{
    public class Publisher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int PubId { get; set; }
        public String PublisherName { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Country { get; set; }
    }
}
