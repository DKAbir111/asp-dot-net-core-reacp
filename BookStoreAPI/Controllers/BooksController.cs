using BookStore.Data.Interfaces;
using BookStore.Data.Models;
using BookStore.Data.Repositories;
//using BookStoreAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        //        public List<Book> books = new List<Book>() {
        //new Book { Id = 1, Title = "The Girl on the Train", Author = "Hawkins, Paula", PublicationYear = 2015, CallNumber = "F HAWKI"},
        //new Book { Id = 2, Title = "Rogue Lawyer", Author = "Grisham, John", PublicationYear = 2015, CallNumber = "F GRISH"},
        //new Book { Id = 3, Title = "After You", Author = "Moyes, Jojo", PublicationYear = 2015, CallNumber = "F MOYES"},
        //new Book { Id = 4, Title = "All the Light We Cannot See", Author = "Doerr, Anthony", PublicationYear = 2014, CallNumber = "F DOERR"},
        //new Book { Id = 5, Title = "The Girls", Author = "Cline, Emma", PublicationYear = 2016, CallNumber = "F CLINE"},
        //new Book { Id = 6, Title = "The Martian", Author = "Weir, Andy", PublicationYear = 2011, CallNumber = "SF WEIR"},
        //new Book { Id = 7, Title = "Me Before You", Author = "Moyes, Jojo", PublicationYear = 2012, CallNumber = "F MOYES"},
        //new Book { Id = 8, Title = "Alexander Hamilton", Author = "Chernow, Ron", PublicationYear = 2004, CallNumber = "B HAMILTO A"},
        //new Book { Id = 9, Title = "Before the Fall", Author = "Hawley, Noah", PublicationYear = 2016, CallNumber = "F HAWLE"}
        //};

        //private BookRepository books = new BookRepository();
        
        private IBookRepository books;

        public BooksController(IBookRepository _books)
        {
            this.books = _books;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            //return books;
            return books.GetAllBooks();
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            //var book = books.FirstOrDefault(x => x.Id == id);
            var book = books.GetBook(id);

            if (book == null)
            {
                return NotFound();
            }
            return book;
        }

        //use ([FromForm] Book book) when using UI
        [HttpPost]
        public ActionResult<Book> PostBook(Book book)
        {
            if (books.AddNewBook(book))
            {
                return book;
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<Book>> DeleteBook(int id)
        {

            if (books.Remove(id))
            {
                return books.GetAllBooks();
            }
            return NotFound();
        }

        //use (int id, [FromForm]Book book) when using UI
        [HttpPut("{id}")]
        public ActionResult<IEnumerable<Book>> UpdateBook(int id, Book book)
        {
            var ubook = books.UpdateBook(id, book);
            if (ubook != null)
            {
                return ubook;
            }
            return NotFound();
        }



        //https://localhost:44393/api/books/author/Hawkins
        //https://localhost:44393/api/books/authorname/Hawkins
        [HttpGet]
        [Route("author/{name}")]
        [Route("authorname/{name}")]
        public ActionResult<IEnumerable<Book>> GetBooksByAuthor(string name)
        {
            var result = books.GetBooksByAuthor(name);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

        //https://localhost:44393/api/books/4/author
        //https://localhost:44393/api/books/authorid/2
        [HttpGet]
        [Route("{id}/author")]
        [Route("authorid/{id}")]
        public ActionResult<string> GetAuthorById(int id)
        {
            var name = books.GetAuthorById(id);
            if (name == null)
            {
                return NotFound();
            }
            return name;
        }

        //https://localhost:44393/api/books/author/sara/year/2002
        [HttpGet]
        [Route("author/{author}/year/{year}")]
        public ActionResult<Book> GetBookByAuthorAndYear(string author, int year)
        {
            var book = books.GetBookByAuthorAndYear(author, year);
            if (book == null)
            {
                return NotFound();
            }
            return book;
        }


        [HttpPut]
        [Route("updatecost/{id}")]
        public ActionResult<Book> AddCost(int id, [FromForm] Cost cost)
        {
            Book result = books.AddCost(id, cost);
            if (result != null)
            {
                return result;
            }
            return NotFound();
        }



    }
}
