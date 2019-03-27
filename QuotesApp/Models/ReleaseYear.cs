using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesApp.Models
{
    public class ReleaseYear
    {
        public Int16 Year { get; set; }
        public string SearchYear { get; set; }
        public List<Movie> Movies;
        public SelectList Years;

    }
}
