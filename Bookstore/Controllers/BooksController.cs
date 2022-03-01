using Microsoft.AspNetCore.Mvc;
using Bookstore.Repositories;
using Bookstore.Entities;
using Bookstore.Dtos;

namespace Bookstore.Controllers
{
    [ApiController]
    [Route("Books")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository repository;

        public BooksController(IBooksRepository repository)
        {
            this.repository = repository;
        }

        //GET /books
        [HttpGet]
        public IEnumerable<BookDto> GetBooks() => repository.GetBooks().Select(book => book.AsDto());

        //GET /books/{id}
        [HttpGet("{id}")]
        public ActionResult<BookDto> GetBook(Guid id) 
        {
            var book =repository.GetBook(id);
            return (book == null)? NotFound(): book.AsDto();
             
        }

        //POST /books
        [HttpPost]
        public ActionResult<BookDto> AddBook(BookDto bookDto)
        {
            Book book = new()
            {
                Id= Guid.NewGuid(),
                Name = bookDto.Name,
                Author = bookDto.Author,
                Price = bookDto.Price
            };  
            repository.AddBook(book);

            return CreatedAtAction(nameof(GetBook), new {id = book.Id}, book.AsDto());

        }

        //PUT /books/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateBook(Guid id, BookDto book)
        {
            var existingBook = repository.GetBook(id);
            if(existingBook is null)
            {
                return NotFound();
            }
            Book updatedBook = existingBook with
            {
                Name = book.Name,
                Author = book.Author,
                Price = book.Price
            };
            repository.UpdateBook(updatedBook);
            return NoContent();
        }

        //DELETE /books/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteBook(Guid id)
        {
            var book = repository.GetBook(id);
            if(book is null)
            {
                return NotFound();
            }
            repository.DeleteBook(id);
            return NoContent();
        }

    }
}