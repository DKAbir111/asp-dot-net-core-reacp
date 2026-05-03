using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Model
{
    public class BookApiContext : DbContext
    {

        public BookApiContext(DbContextOptions<BookApiContext> options)
            : base(options)
        {
        }

        public DbSet<Books> Books { get; set; }

    }
}