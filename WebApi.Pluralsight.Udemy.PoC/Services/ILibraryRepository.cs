using System;
using System.Collections.Generic;
using WebApi.Pluralsight.Udemy.PoC.Entities;
using WebApi.Pluralsight.Udemy.PoC.ResourceParameters;

namespace WebApi.Pluralsight.Udemy.PoC.Services
{
    public interface ILibraryRepository
    {
        IEnumerable<Book> GetBooks(Guid authorId);
        Book GetBook(Guid authorId, Guid courseId);
        void AddBook(Guid authorId, Book course);
        void UpdateBook(Book course);
        void DeleteBook(Book course);
        IEnumerable<Author> GetAuthors();
        IEnumerable<Author> GetAuthors(IEnumerable<Guid> authorIds);
        IEnumerable<Author> GetAuthors(AuthorsResourceParameters authorsResourceParameters);
        Author GetAuthor(Guid authorId);
        void AddAuthor(Author author);
        void DeleteAuthor(Author author);
        void UpdateAuthor(Author author);
        bool AuthorExists(Guid authorId);
        bool Save();
    }
}
