using Assignment2.DataAccess.DTOs.Books;
using Assignment2.DataAccess.Entities;

namespace Assignment2.Service.Services.BookService
{
    public interface IBookService
    {
        IQueryable<Book> ListAllBook();
        bool Delete(int id);
        CreateBookReponse Create(CreateBookRequest book);
        UpdateBookResponse Update(UpdateBookRequest updateBook,int id);

    }
}
