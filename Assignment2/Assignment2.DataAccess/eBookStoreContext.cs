using Assignment2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.DataAccess
{
    public class eBookStoreContext : DbContext
    {
        public eBookStoreContext(DbContextOptions<eBookStoreContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>().HasKey(sc => new { sc.BookId, sc.AuthorId });

            modelBuilder.Entity<BookAuthor>()
                        .HasOne(sc => sc.Book)
                        .WithMany(s => s.bookAuthors)
                        .HasForeignKey(sc => sc.BookId);

            modelBuilder.Entity<BookAuthor>()
                        .HasOne<Author>(sc => sc.Author)
                        .WithMany(s => s.BookAuthorList)
                        .HasForeignKey(sc => sc.AuthorId);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
