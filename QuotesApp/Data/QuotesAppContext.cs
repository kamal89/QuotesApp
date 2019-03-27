using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace QuotesApp.Models
{
    public class QuotesAppContext : DbContext
    {
        public QuotesAppContext (DbContextOptions<QuotesAppContext> options)
            : base(options)
        {
        }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<MovieQuote> MovieQuote { get; set; }

    }
}
