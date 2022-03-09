using Microsoft.AspNetCore.Mvc;
using Bookstore.Services;
using Bookstore.Entities;

namespace Bookstore.Controllers;

[ApiController]
[Route("Books")]
public class BooksController : ControllerBase
{
    private readonly BooksService booksService;

    public BooksController(BooksService booksService)
    {
        this.booksService = booksService;
    }

    //GET /books
    public async Task<List<Book>> Get() => await booksService.GetAsync();

    //GET /books/{id}
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Book>> Get(string id)
    {
        var book = await booksService.GetAsync(id);
        return (book == null)? NotFound(): book;
    }

    //POST /books
     [HttpPost]
    public async Task<IActionResult> Post(Book newBook)
    {
        await booksService.CreateAsync(newBook);

        return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
    }

    //PUT /books/{id}
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Book updatedBook)
    {
        var book = await booksService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        updatedBook.Id = book.Id;

        await booksService.UpdateAsync(id, updatedBook);

        return NoContent();
    }
    //DELETE /books/{id}
    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var book = await booksService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        await booksService.RemoveAsync(id);

        return NoContent();
    }

}
