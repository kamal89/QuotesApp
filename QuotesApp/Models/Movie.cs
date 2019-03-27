using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesApp.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        [Required]
        public string Title { get; set; }
        [Display(Name = "Release Year")]
        [Range(1, 9999)]
        public Int16 ReleaseYear { get; set; }
        public ICollection<MovieQuote> MovieQuotes { get; set; } = new List<MovieQuote>();
    }
}
