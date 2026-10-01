using System.ComponentModel.DataAnnotations;

namespace BookCatalogApi.DTOs;

public class BookDto
{
    public int Id { get; set; }

    [Required, MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string Author { get; set; } = string.Empty;

    [Range(1, 9999)]
    public int Year { get; set; }

    [Range(0, 1000000)]
    public decimal Price { get; set; }

    [MaxLength(2000)]
    public string? Description { get; set; }
}
