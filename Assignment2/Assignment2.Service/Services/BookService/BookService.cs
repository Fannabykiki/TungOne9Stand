using Assignment2.DataAccess.DTOs.Books;
using Assignment2.DataAccess.Entities;
using Assignment2.DataAccess.Repositories.Interfaces;
using static System.Reflection.Metadata.BlobBuilder;

namespace Assignment2.Service.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookAuthorRepository _bookAuthorRepository;
        private readonly IAuthorRepository _authorRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public CreateBookReponse Create(CreateBookRequest book)
        {
            try
            {
                var requestBook = new Book
                {
                    Title = book.Title,
                    Type = book.Type,
                    Notes = book.Notes,
                    Price = book.Price,
                    Royalty = book.Royalty,
                    YtdSales = book.YtdSales,
                    Advance = book.Advance,
                    Pub_Id = book.Pub_Id,
                    PublishedDate = book.PublishedDate
                };
              
                var newBook =  _bookRepository.Create(requestBook);

                foreach (var authorId in book.authorIds)
                {
                    var author = _authorRepository.Get(s => s.Id == authorId);
                    if (author == null)
                    {
                        return new CreateBookReponse
                        {
                            IsSucced = false,
                        };
                    }
                    if (author != null)
                    {
                        var newBookAuthor= new BookAuthor
                        {
                             Book = newBook,
                             Author = author,
                             AuthorOrder = book.AuthorOrder,
                             RoyalityPercentage = book.RoyalityPercentage,
                        };
                        _bookAuthorRepository.Create(newBookAuthor);
                    }
                }
                _bookRepository.SaveChanges();
                _bookAuthorRepository.SaveChanges();

                return new CreateBookReponse
                {
                    IsSucced = true,
                };
            }
            catch (Exception)
            {
                return new CreateBookReponse
                {
                    IsSucced = true,
                };
            }
        }

    

        public IQueryable<Book> ListAllBook()
        {
            return (_bookRepository.GetAll(x => true)).AsQueryable();
        }

        public UpdateBookResponse Update(UpdateBookRequest updateBook,int id)
        {
            try
            {
                var book =  _bookRepository.Get(s => s.Id == id);
                if (book == null)
                {
                    return new UpdateBookResponse
                    {
                        IsSucced = false,
                    };
                }

                book.Title = updateBook.Title;
                book.Price = updateBook.Price;
                book.Advance = updateBook.Advance;
                book.Notes = updateBook.Notes;
                book.Royalty= updateBook.Royalty;
                book.YtdSales = updateBook.YtdSales;
                book.PublishedDate= updateBook.PublishedDate;
                book.Type = updateBook.Type;
                book.Pub_Id = updateBook.Pub_Id;

                var newBook =  _bookRepository.Update(book);
                _bookRepository.SaveChanges();

                var bookAuthor =  _bookAuthorRepository.GetAll(s => s.BookId == id);
                foreach (var item in bookAuthor)
                {
                     _bookAuthorRepository.Delete(item);
                    _bookAuthorRepository.SaveChanges();
                }
                foreach (var authorIds in updateBook.authorIds)
                {
                    var author =  _authorRepository.Get(s => s.Id == authorIds);

                    var newBookAuthor = new BookAuthor
                    {
                        Book = newBook,
                        Author = author,
                        AuthorOrder = updateBook.AuthorOrder,
                        RoyalityPercentage= updateBook.RoyalityPercentage,
                    };
                    _bookAuthorRepository.Create(newBookAuthor);
                }
                _bookAuthorRepository.SaveChanges();

                return new UpdateBookResponse
                {
                    IsSucced = true,
                };
            }
            catch (Exception)
            {
                return new UpdateBookResponse
                {
                    IsSucced = false,
                }; ;
            }
        }

        bool IBookService.Delete(int id)
        {
            var book = _bookRepository.Get(c => c.Id == id);
            if (book == null)
            {
                return false;
            }
            _bookRepository.Delete(book);

            _bookRepository.SaveChanges();

            return true;
        }

    }
}
