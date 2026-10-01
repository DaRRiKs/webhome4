using AutoMapper;
using BookCatalogApi.Common;
using BookCatalogApi.DTOs;
using BookCatalogApi.Models;
using BookCatalogApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalogApi.Controllers;

[ApiController]
[Route("api/books")]
public class BooksController(IBookRepository repository, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ReturnResult<List<BookDto>>>> GetAll()
    {
        var books = await repository.GetAll();
        return Ok(new ReturnResult<List<BookDto>>(true, mapper.Map<List<BookDto>>(books), "Books retrieved."));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ReturnResult<BookDto>>> GetById(int id)
    {
        var book = await repository.GetById(id);
        if (book is null)
        {
            return NotFound(new ReturnResult<BookDto>(false, null, "Book not found."));
        }

        return Ok(new ReturnResult<BookDto>(true, mapper.Map<BookDto>(book), "Book retrieved."));
    }

    [HttpPost]
    public async Task<ActionResult<ReturnResult<BookDto>>> Add(BookDto dto)
    {
        var book = await repository.Add(mapper.Map<Book>(dto));
        var result = new ReturnResult<BookDto>(true, mapper.Map<BookDto>(book), "Book created.");
        return CreatedAtAction(nameof(GetById), new { id = book.Id }, result);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ReturnResult<BookDto>>> Update(int id, BookDto dto)
    {
        var book = await repository.GetById(id);
        if (book is null)
        {
            return NotFound(new ReturnResult<BookDto>(false, null, "Book not found."));
        }

        mapper.Map(dto, book);
        await repository.Update(book);
        return Ok(new ReturnResult<BookDto>(true, mapper.Map<BookDto>(book), "Book updated."));
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ReturnResult<bool>>> Delete(int id)
    {
        if (!await repository.Delete(id))
        {
            return NotFound(new ReturnResult<bool>(false, false, "Book not found."));
        }

        return Ok(new ReturnResult<bool>(true, true, "Book deleted."));
    }

    [HttpGet("search")]
    public async Task<ActionResult<ReturnResult<List<BookDto>>>> SearchByAuthor([FromQuery] string? author)
    {
        if (string.IsNullOrWhiteSpace(author))
        {
            return BadRequest(new ReturnResult<List<BookDto>>(false, null, "Author is required."));
        }

        var books = await repository.SearchByAuthor(author);
        return Ok(new ReturnResult<List<BookDto>>(true, mapper.Map<List<BookDto>>(books), "Books retrieved."));
    }
}
