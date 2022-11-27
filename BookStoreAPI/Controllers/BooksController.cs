using BookStoreAPI.Models;
using BookStoreAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetOneBook([FromRoute] int id)
        {
            var book = await _bookRepository.GetOneBooksAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost("add-book")]

        public async Task<IActionResult> AddBook([FromBody] BookModel model)
        {
            var message = await _bookRepository.AddNewBookAsync(model);
            return Ok(message);
        }
    }
}
