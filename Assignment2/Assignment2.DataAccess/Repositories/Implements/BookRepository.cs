using Assignment2.DataAccess.Entities;
using Assignment2.DataAccess.Repositories.Interfaces;
using BookStore.Data.Repositories.Implements;

namespace Assignment2.DataAccess.Repositories.Implements
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(eBookStoreContext context) : base(context)
        {
        }
    }
}
