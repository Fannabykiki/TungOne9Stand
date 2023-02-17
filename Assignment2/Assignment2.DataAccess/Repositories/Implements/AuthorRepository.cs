using Assignment2.DataAccess.Entities;
using Assignment2.DataAccess.Repositories.Interfaces;
using BookStore.Data.Repositories.Implements;

namespace Assignment2.DataAccess.Repositories.Implements
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(eBookStoreContext context) : base(context)
        {

        }
    }
}
