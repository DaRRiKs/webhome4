using System.ComponentModel.DataAnnotations;

namespace BookCatalogApi.Models;

public class Book
{
    public int Id { get; set; }

    [Required, MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string Author { get; set; } = string.Empty;

    public int Year { get; set; }

    public decimal Price { get; set; }

    [MaxLength(2000)]
    public string? Description { get; set; }
}
