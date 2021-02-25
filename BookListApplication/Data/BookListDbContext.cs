using BookListApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListApplication.Data
{
    public class BookListDbContext : DbContext
    {
        public BookListDbContext(DbContextOptions<BookListDbContext> options)
            : base(options)
        {

        }

        //Properties to push into database
        public DbSet<Category> Categories { get; set; }
        public DbSet<CatType> CatTypes { get; set; }
    }
}
