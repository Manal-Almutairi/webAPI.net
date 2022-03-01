using System.ComponentModel.DataAnnotations;
namespace Bookstore.Dtos
{
    public record BookDto
    {
        public Guid Id { get; init;} = Guid.NewGuid();
        [Required]
        public string Name { get; init;}
        [Required]
        public string Author { get; init;}
        [Required]
        [Range(1,1000)]
        public double Price { get; init;}

    }
}