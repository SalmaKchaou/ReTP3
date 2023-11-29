using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ReTP3.Models;

namespace ReTP3.Services
{
    public class MovieService : IMovieService
    {
        private readonly AppDbContext _db;

        public MovieService(AppDbContext context)
        {
            _db = context;
        }

        public List<Movie> GetMoviesByGenre(int genreId)
        {
            var movies = _db.movies
                .Where(m => m.GenreId == genreId)
                .ToList();

            return movies;
        }
        public List<Movie> GetMoviesOrderedByName()
        {
            var movies = _db.movies
                .OrderBy(m => m.Name)
                .ToList();

            return movies;
        }
        public List<Movie> GetMoviesByGenreId(int genreId)
        {
            var movies = _db.movies
                .Where(m => m.GenreId == genreId)
                .ToList();

            return movies;
        }
    }
}
