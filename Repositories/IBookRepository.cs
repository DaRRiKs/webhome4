using BookCatalogApi.Models;

namespace BookCatalogApi.Repositories;

public interface IBookRepository
{
    Task<List<Book>> GetAll();
    Task<Book?> GetById(int id);
    Task<Book> Add(Book book);
    Task Update(Book book);
    Task<bool> Delete(int id);
    Task<List<Book>> SearchByAuthor(string author);
}
