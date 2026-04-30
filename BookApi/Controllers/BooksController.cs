using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Data.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace BookApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private BookRepository books = new BookRepository();
        [HttpGet]
        public IActionResult GetBook()
        {
            return Ok(books.GetBooks());
        }


        [HttpGet("{id}")]
            public IActionResult GetBookById(int id )
         {
            var book = books.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

    }
}

