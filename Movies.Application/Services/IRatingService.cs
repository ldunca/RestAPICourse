using Movies.Application.Models;

namespace Movies.Application.Services;

public interface IRatingService
{
    Task<bool> RateMovieAsync(Guid movieId, int rating, Guid userId, CancellationToken token = default);
    Task<bool> DeleteAsync(Guid movieId, Guid userId, CancellationToken token = default);
    
    Task<IEnumerable<MovieRating>> GetRattingsForUserAsync(Guid userId, CancellationToken token = default);
}