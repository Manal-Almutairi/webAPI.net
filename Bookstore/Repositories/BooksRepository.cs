using System.Collections.Generic;
using Bookstore.Entities;

namespace Bookstore.Repositories
{

    public class BooksRepository : IBooksRepository
    {
        private readonly List<Book> Books = new()
        {
            new Book { Id = Guid.NewGuid(), Name = "The Bitcoin Standard", Author = "Saifedean Ammous" , Price = 13.89},
            new Book { Id = Guid.NewGuid(), Name = "CompTIA A+ Certification All-in-One Exam Guide" , Author = "Mike Meyers", Price = 23.53 },
            new Book { Id = Guid.NewGuid(), Name = "System Design Interview ", Author = "Alex Xu" , Price = 35.99}
        };

        public IEnumerable<Book> GetBooks() => Books;

        public Book GetBook(Guid id) => Books.Where(Book => Book.Id == id).SingleOrDefault();

        public void AddBook(Book book) => Books.Add(book);

        public void UpdateBook(Book book) => Books[Books.FindIndex( x => x.Id == book.Id)]= book; 

        public void DeleteBook(Guid id) => Books.RemoveAt(Books.FindIndex( x => x.Id == id));
    }
}