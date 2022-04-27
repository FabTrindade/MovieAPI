using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MovieAPI.Data.Dtos;
using MovieAPI.Models;

namespace MovieAPI.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap <CreateMovieDto, Movie>(); 
            CreateMap <Movie, GetMovieDto>(); 
            CreateMap <UpdateMovieDto, Movie>();             
        }        
    }

}