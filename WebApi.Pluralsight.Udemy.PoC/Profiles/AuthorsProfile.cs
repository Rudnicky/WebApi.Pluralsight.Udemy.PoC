using AutoMapper;
using WebApi.Pluralsight.Udemy.PoC.Entities;
using WebApi.Pluralsight.Udemy.PoC.Helpers;
using WebApi.Pluralsight.Udemy.PoC.Models;

namespace WebApi.Pluralsight.Udemy.PoC.Profiles
{
    public class AuthorsProfile : Profile
    {
        public AuthorsProfile()
        {
            CreateMap<Author, AuthorDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge()));

            CreateMap<AuthorCreationDto, Author>();
        }
    }
}
