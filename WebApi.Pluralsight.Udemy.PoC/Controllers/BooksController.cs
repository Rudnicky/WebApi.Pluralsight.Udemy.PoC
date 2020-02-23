using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApi.Pluralsight.Udemy.PoC.Entities;
using WebApi.Pluralsight.Udemy.PoC.Models;
using WebApi.Pluralsight.Udemy.PoC.Services;

namespace WebApi.Pluralsight.Udemy.PoC.Controllers
{
    [ApiController]
    [Route("api/authors/{authorId}/books")]
    public class BooksController : ControllerBase
    {
        private readonly ILibraryRepository _libraryRepository;
        private readonly IMapper _mapper;

        public BooksController(ILibraryRepository libraryRepository, IMapper mapper)
        {
            _libraryRepository = libraryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookDto>> GetBooksForAuthor(Guid authorId)
        {
            if (!_libraryRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var booksForAuthorFromRepo = _libraryRepository.GetBooks(authorId);
            var books = _mapper.Map<IEnumerable<BookDto>>(booksForAuthorFromRepo);

            return Ok(books);
        }

        [HttpGet("{bookId}", Name = "GetBookForAuthor")]
        public ActionResult<BookDto> GetBookForauthor(Guid authorId, Guid bookId)
        {
            if (!_libraryRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var bookForAuthorFromRepo = _libraryRepository.GetBook(authorId, bookId);
            if (bookForAuthorFromRepo == null)
            {
                return NotFound();
            }

            var book = _mapper.Map<BookDto>(bookForAuthorFromRepo);

            return Ok(book);
        }

        [HttpPost]
        public ActionResult<BookDto> CreateBookForAuthor(Guid authorId, BookCreationDto book)
        {
            if (!_libraryRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var bookEntity = _mapper.Map<Book>(book);
            _libraryRepository.AddBook(authorId, bookEntity);
            _libraryRepository.Save();

            var bookToReturn = _mapper.Map<BookDto>(bookEntity);

            return CreatedAtAction("GetBookForAuthor", new { authorId = authorId, bookId = bookToReturn.Id }, bookToReturn);
        }
    }
}
