using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;

namespace MovieAPI.Data
{
    public class MoviesContext : DbContext
    {
        
        public MoviesContext (DbContextOptions <MoviesContext> opt ) : base(opt)
        {

        }

        public DbSet<Movie> Movies {get; set;}

    }
}