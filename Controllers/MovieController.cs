using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieAPI.Models;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private List<Movie> movies = new List<Movie>();

        [HttpPost]
        public void AddMovie([FromBody] Movie movie)
        {
            movies.Add(movie);
            Console.WriteLine(movie.Title);
        }
    }
}
