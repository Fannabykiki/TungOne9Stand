using Assignment2.DataAccess.Entities;

namespace Assignment2.DataAccess.DTOs.Books
{
    public class CreateBookRequest
    {
        public String Title { get; set; }
        public String Type { get; set; }
        public int Pub_Id { get; set; }
        public double Price { get; set; }
        public float Royalty { get; set; }
        public int YtdSales { get; set; }
        public String Notes { get; set; }
        public DateTime PublishedDate { get; set; }
        public String Advance { get; set; }
        public String AuthorOrder { get; set; }
        public double RoyalityPercentage { get; set; }
        public List<int> authorIds { get; set; }
    }
}
