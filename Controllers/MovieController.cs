using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieAPI.Data;
using MovieAPI.Models;
using MovieAPI.Data.Dtos;

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
        public IActionResult AddMovie([FromBody] CreateMovieDto movieDto)
        {
           Movie movie = new Movie
           {
               Title = movieDto.Title,
               Director = movieDto.Director,
               Genre = movieDto.Genre,
               Duration = movieDto.Duration
           };
           _contex.Movies.Add(movie);
            _contex.SaveChanges();
            return CreatedAtAction(nameof(GetMoviesById), new {Id = movie.Id}, movie);
        }
        
        [HttpGet]
        public IEnumerable<Movie> GetMovies()
        {
            return (_contex.Movies);
        }

        [HttpGet("{id}")]
        public IActionResult GetMoviesById(int id)
        {
            Movie movie = _contex.Movies.FirstOrDefault(movie => movie.Id == id);            
            if (movie != null)
            {
                 NotFound();
            }
            GetMovieDto movieDto = new GetMovieDto
            {
                Title = movie.Title,
                Director = movie.Director,
                Genre = movie.Genre,
                Duration = movie.Duration,
                ConsultTime = DateTime.Now
            };
            
            return Ok(movieDto);
        }

        [HttpPut ("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDto movieDto)
        {
            Movie movie = _contex.Movies.FirstOrDefault(movie => movie.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            movie.Title = movieDto.Title;
            movie.Director = movieDto.Director;
            movie.Genre= movieDto.Genre;
            movie.Duration = movieDto.Duration;
            _contex.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteMovie (int id)
        {
            Movie movie = _contex.Movies.FirstOrDefault(movie => movie.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            _contex.Remove(movie);
            _contex.SaveChanges();

            return NoContent();
        }

    }
}
