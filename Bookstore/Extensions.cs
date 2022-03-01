using Bookstore.Dtos;
using Bookstore.Entities;

namespace Bookstore
{
    public static class Extensions
    {
        public static BookDto AsDto( this Book book)
        {
         return new BookDto
        {
            Id = book.Id,
            Name = book.Name,
            Author = book.Author,
            Price = book.Price
        };   
        }
    }
}