using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApi.Pluralsight.Udemy.PoC.Entities;
using WebApi.Pluralsight.Udemy.PoC.Models;
using WebApi.Pluralsight.Udemy.PoC.ResourceParameters;
using WebApi.Pluralsight.Udemy.PoC.Services;

/// <summary>
/// [DEBUG] ]In terms of throwing exception DO NOT expose implementation
/// in order to do that, open properties of project/Debug section
/// and change ASPNETCORE_ENVIRONMENT from development to 'Production'
/// 
/// [Complex object such as AuthorsResourceParameters] are inferred
/// from the request body as default until we explicitly use [FromQuery] attribute
/// </summary>
/// 


namespace WebApi.Pluralsight.Udemy.PoC.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly ILibraryRepository _libraryRepository;
        private readonly IMapper _mapper;

        public AuthorsController(ILibraryRepository libraryRepository, IMapper mapper)
        {
            _libraryRepository = libraryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AuthorDto>> GetAuthors(
            [FromQuery] AuthorsResourceParameters authorsResourceParameters)
        {
            var authorsFromRepo = _libraryRepository.GetAuthors(authorsResourceParameters);
            var authors = _mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo);

            return Ok(authors);
        }

        [HttpGet("{authorId}", Name = "GetAuthor")]
        public IActionResult GetAuthor(Guid authorId)
        {
            var authorFromRepo = _libraryRepository.GetAuthor(authorId);

            if (authorFromRepo == null)
            {
                return NotFound();
            }

            var author = _mapper.Map<AuthorDto>(authorFromRepo);

            return Ok(author);
        }

        [HttpPost]
        public ActionResult<AuthorDto> CreateAuthor(AuthorCreationDto author)
        {
            var authorEntity = _mapper.Map<Author>(author);
            _libraryRepository.AddAuthor(authorEntity);
            _libraryRepository.Save();

            var authorToReturn = _mapper.Map<AuthorDto>(authorEntity);

            // this refers to public IActionResult GetAuthor(Guid authorId)
            // which has it's own Name GetAuthor plus parameters.
            return CreatedAtRoute("GetAuthor", new { authorId = authorToReturn.Id }, authorToReturn);
        }
    }
}
