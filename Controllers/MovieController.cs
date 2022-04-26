using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieAPI.Data;
using MovieAPI.Models;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private MoviesContext _contex;

        public MovieController(MoviesContext contex)
        {
            _contex = contex;
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            _contex.Movies.Add(movie);
            _contex.SaveChanges();
            return CreatedAtAction(nameof(GetMoviesById), new {Id = movie.Id}, movie);
        }
        
        [HttpGet]
        public IEnumerable<Movie> GetMovies()
        {
            return (_contex.Movies);
        }

        [HttpGet("{Id}")]
        public IActionResult GetMoviesById(int id)
        {
            Movie movie = _contex.Movies.FirstOrDefault(movie => movie.Id == id);            
            return (movie != null)? Ok(movie) : NotFound();
        }

    }
}
