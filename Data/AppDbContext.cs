using BookCatalogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCatalogApi.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Book> Books => Set<Book>();
}
