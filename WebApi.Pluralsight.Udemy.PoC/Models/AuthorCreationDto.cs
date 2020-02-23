using System;
using System.Collections.Generic;

namespace WebApi.Pluralsight.Udemy.PoC.Models
{
    public class AuthorCreationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string MainCategory { get; set; }
        public ICollection<BookCreationDto> Books { get; set; } = new List<BookCreationDto>();
    }
}
