using Movies.Application.Models;

namespace Movies.Application.Repository;

public interface IRatingRepository
{
    Task<bool> RateMovieAsync(Guid movieId, int rating, Guid userId, CancellationToken token = default);
    Task<float?> GetRatingAsync(Guid movieId, CancellationToken token = default);
    
    Task<bool> DeleteAsync(Guid movieId, Guid userId, CancellationToken token = default);

    Task<(float? Rating, int? UserRating)> GetUserRatingAsync(Guid movieId, Guid userId,
        CancellationToken token = default);
    
    Task<IEnumerable<MovieRating>> GetUserRatingsAsync(Guid userId, CancellationToken token = default);
}