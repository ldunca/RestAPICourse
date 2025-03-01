using Movies.Application.Models;

namespace Movies.Application.Repository;

public interface IMovieRepository
{
    Task<bool> CreateMovieAsync(Movie movie, CancellationToken token = default);
    Task<IEnumerable<Movie>> GetAllAsync(Guid? userId, CancellationToken token = default);
    Task<Movie?> GetByIdAsync(Guid id, Guid? userId, CancellationToken token = default);
    
    Task<Movie?> GetBySlugAsync(string slug, Guid? userId, CancellationToken token = default);
    Task<bool> UpdateAsync(Movie movie, CancellationToken token = default);
    Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default);
    
    Task<bool> ExistsByIdAsync(Guid id, CancellationToken token = default);
}