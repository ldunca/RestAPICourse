using Movies.Application.Models;

namespace Movies.Application.Repository;

public interface IMovieRepository
{
    Task<bool> CreateMovieAsync(Movie movie);
    Task<IEnumerable<Movie>> GetAllAsync();
    Task<Movie?> GetByIdAsync(Guid id);
    Task<bool> UpdateAsync(Movie movie);
    Task<bool> DeleteByIdAsync(Guid id);
}