using BookStore.Data.Interfaces;
using BookStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.Data.Repositories
{
    public class BookDatabase : IBookRepository
    {
        private BookStoreContext db;

        public BookDatabase(BookStoreContext _db)
        {
            this.db = _db;
        }



        public List<Book> GetAllBooks()
        {
            //return db.Books.ToList();
            return db.Books.Include(x => x.Cost).ToList();
        }

        public Book GetBook(int id)
        {
            //return db.Books.FirstOrDefault(x => x.Id == id);
            return db.Books.Include(x => x.Cost).FirstOrDefault(x => x.Id == id);
        }

        public bool AddNewBook(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
            return true;

        }

        public bool Remove(int id)
        {
            var book = GetBook(id);
            if (book == null)
            {
                return false;
            }
            db.Books.Remove(book);
            db.SaveChanges();
            return true;

        }

        public List<Book> UpdateBook(int id, Book book)
        {
            if (this.Remove(id))
            {
                this.AddNewBook(book);
                db.SaveChanges();
                return db.Books.ToList();
            }
            return db.Books.ToList();

        }

        public List<Book> GetBooksByAuthor(string name)
        {
            return db.Books.Where(x => x.Author.Contains(name)).ToList();
        }

        public string GetAuthorById(int id)
        {
            return db.Books.FirstOrDefault(x => x.Id == id).Author;
        }

        public Book GetBookByAuthorAndYear(string author, int year)
        {
            return db.Books.FirstOrDefault(x => x.PublicationYear == year && x.Author.Contains(author));
        }

        public Book AddCost(int id, Cost cost)
        {
            Book book = GetBook(id);
            book.Cost = cost;
            db.SaveChanges();
            return book;
        }

    }
}
