using System;
using BookStore.Data.Interfaces;
using BookStore.Data.Models;

namespace BookStore.Data.Repositories
{
    public class BookRepository : IBookRepository
    {

        public List<Books> books = new List<Books>
{
    new Books { Id = 1, Title = "Clean Code", Author = "Robert C. Martin", PublicationYear = 2008, IsAvaialable = true, CallNumber = "QA76.76.D47 C54" },
    new Books { Id = 2, Title = "The Pragmatic Programmer", Author = "Andrew Hunt", PublicationYear = 1999, IsAvaialable = true, CallNumber = "QA76.6 H86" },
    new Books { Id = 3, Title = "Introduction to Algorithms", Author = "Thomas H. Cormen", PublicationYear = 2009, IsAvaialable = false, CallNumber = "QA76.6 C66" },
    new Books { Id = 4, Title = "Design Patterns", Author = "Erich Gamma", PublicationYear = 1994, IsAvaialable = true, CallNumber = "QA76.64 D47" },
    new Books { Id = 5, Title = "Refactoring", Author = "Martin Fowler", PublicationYear = 2018, IsAvaialable = true, CallNumber = "QA76.76.R42 F69" },
    new Books { Id = 6, Title = "You Don't Know JS", Author = "Kyle Simpson", PublicationYear = 2015, IsAvaialable = false, CallNumber = "QA76.73.J38 S56" },
    new Books { Id = 7, Title = "C# in Depth", Author = "Jon Skeet", PublicationYear = 2019, IsAvaialable = true, CallNumber = "QA76.73.C154 S54" },
    new Books { Id = 8, Title = "ASP.NET Core in Action", Author = "Andrew Lock", PublicationYear = 2018, IsAvaialable = true, CallNumber = "QA76.76.A65 L63" },
    new Books { Id = 9, Title = "Head First Design Patterns", Author = "Eric Freeman", PublicationYear = 2004, IsAvaialable = false, CallNumber = "QA76.64 F74" },
    new Books { Id = 10, Title = "The Clean Coder", Author = "Robert C. Martin", PublicationYear = 2011, IsAvaialable = true, CallNumber = "QA76.76.D47 C53" }
};

        public Books? GetBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            return book; // can be null
        }

        public List<Books> GetBooks()
        {

            return books;
        }
    }
}

