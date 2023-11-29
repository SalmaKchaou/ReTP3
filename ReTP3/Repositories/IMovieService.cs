using ReTP3.Models;

namespace ReTP3.Services
{
    public interface IMovieService
    {
        List<Movie> GetMoviesByGenre(int genreId);
        List<Movie> GetMoviesOrderedByName();
        List<Movie> GetMoviesByGenreId(int genreId);
    }
}