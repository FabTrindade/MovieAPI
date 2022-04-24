using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MovieAPI.Models
{
    public class Movie
    {
        [Required (ErrorMessage = "The Title field is required.")]
        public string Title { get; set; }
        [Required (ErrorMessage = "The Diector field is required.")]
        public string Director { get; set; }
        public string Genre { get; set; }        
        [Range(1, 360)]
        public int Duration { get; set; }        
        
    }
}
