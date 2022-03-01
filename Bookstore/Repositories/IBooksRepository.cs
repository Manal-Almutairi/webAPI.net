using Bookstore.Entities;


namespace Bookstore.Repositories
{
    public interface IBooksRepository
    {
        Book GetBook(Guid id);
        IEnumerable<Book> GetBooks();
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Guid id);

    }
}