using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesApp.Models
{
    public class MovieQuote
    {
        public int MovieQuoteId { get; set; }
        [Required]
        public string Quote { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
