using AutoMapper;
using WebApi.Pluralsight.Udemy.PoC.Entities;
using WebApi.Pluralsight.Udemy.PoC.Models;

namespace WebApi.Pluralsight.Udemy.PoC.Profiles
{
    public class BooksProfile : Profile
    {
        public BooksProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookCreationDto, Book>();
        }
    }
}
