using BookStoreApi.Models;
using BookStoreApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;

        public BooksController(IBooksRepository booksRepository)
        {
           _booksRepository = booksRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllbooks()
        {
            var Books = await _booksRepository.GetAllBooksAysnc();
            return Ok(Books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetbookById([FromRoute]int id)
        {
            var Book = await _booksRepository.GetBookByIdAsync(id);
            if (Book == null)
            {
                return NotFound();
            }
            return Ok(Book);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddBook([FromBody]BookModels bookModels )
        {
            var id = await _booksRepository.AddBookAsync(bookModels);
            return CreatedAtAction(nameof(GetbookById),new {id = id,controller = "Books"},id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromBody] BookModels bookModels, [FromRoute] int id)
        {
            await _booksRepository.UpdateBookAsync(id,bookModels);
            return Ok();            
        }
    }
}
