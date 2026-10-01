using BookCatalogApi.Data;
using BookCatalogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCatalogApi.Repositories;

public class BookRepository(AppDbContext context) : IBookRepository
{
    public async Task<List<Book>> GetAll()
    {
        return await context.Books.AsNoTracking().ToListAsync();
    }

    public async Task<Book?> GetById(int id)
    {
        return await context.Books.FindAsync(id);
    }

    public async Task<Book> Add(Book book)
    {
        context.Books.Add(book);
        await context.SaveChangesAsync();
        return book;
    }

    public async Task Update(Book book)
    {
        context.Books.Update(book);
        await context.SaveChangesAsync();
    }

    public async Task<bool> Delete(int id)
    {
        var book = await context.Books.FindAsync(id);
        if (book is null)
        {
            return false;
        }

        context.Books.Remove(book);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Book>> SearchByAuthor(string author)
    {
        return await context.Books.AsNoTracking()
            .Where(book => book.Author.Contains(author))
            .ToListAsync();
    }
}
