using Assignment2.DataAccess.DTOs.Books;
using Assignment2.Service.Services.BookService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace Assignment2.API.Controllers
{
    [Route("/api/book-management")]
    [ApiController]
    public class BookManagementController : ControllerBase
    {
        private IBookService _bookService;

        public BookManagementController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult GetAllBook()
        {
            var books = _bookService.ListAllBook();
            return Ok(books);
        }
        [HttpDelete("books/{id}")]
        [EnableQuery]
        public IActionResult DeleteBook(int id)
        {
            var result = _bookService.Delete(id);
            return Ok(result);
        }
        [HttpPost("books")]
        public  IActionResult Create([FromBody] CreateBookRequest addBook)
        {
            var result = _bookService.Create(addBook);

            if (result == null) return StatusCode(500);

            return Ok(result);
        }
    }
}
