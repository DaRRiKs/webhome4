using AutoMapper;
using BookCatalogApi.DTOs;
using BookCatalogApi.Models;

namespace BookCatalogApi.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<BookDto, Book>().ForMember(book => book.Id, options => options.Ignore());
    }
}
