using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MovieAPI.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }        
        public int Duration { get; set; }        
        
    }
}
