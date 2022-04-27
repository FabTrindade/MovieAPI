using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieAPI.Data;
using MovieAPI.Data.Dtos;
using MovieAPI.Models;
using MovieAPI.Profiles;


namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private MoviesContext _contex;
        private IMapper _mapper;

        public MovieController(MoviesContext contex, IMapper mapper)
        {
            _contex = contex;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] CreateMovieDto movieDto)
        {
           Movie movie = _mapper.Map<Movie>(movieDto);

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
            GetMovieDto movieDto = _mapper.Map<GetMovieDto>(movie);
            movieDto.ConsultTime = DateTime.Now;
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

            _mapper.Map(movieDto, movie);
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
