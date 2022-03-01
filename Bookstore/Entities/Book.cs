using System;

namespace Bookstore.Entities
{
    public record Book
    {
        public Guid Id { get; init;}
        public string Name { get; init;}
        public string Author { get; init;}
        public double Price { get; init;}
        
    }
}