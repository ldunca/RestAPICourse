using FluentValidation;
using FluentValidation.Results;
using Movies.Application.Models;
using Movies.Application.Repository;

namespace Movies.Application.Services;

public class RatingService : IRatingService
{
    private readonly IRatingRepository _ratingRepository;
    private readonly IMovieRepository _movieRepository;

    public RatingService(IRatingRepository ratingRepository, IMovieRepository movieRepository)
    {
        _ratingRepository = ratingRepository;
        _movieRepository = movieRepository;
    }

    public async Task<bool> RateMovieAsync(Guid movieId, int rating, Guid userId, CancellationToken token = default)
    {
        if (rating is < 0 or > 5)
        {
            throw new ValidationException(new[]
            {
                new ValidationFailure
                {
                    PropertyName = "Rating",
                    ErrorMessage = "Rating must be between 0 and 5"
                }
            });
        }

        var movieExists = await _movieRepository.ExistsByIdAsync(movieId, token);
        if (!movieExists)
        {
            return false;
        }
        return await _ratingRepository.RateMovieAsync(movieId, rating, userId, token);
    }

    public Task<bool> DeleteAsync(Guid movieId, Guid userId, CancellationToken token = default)
    {
        return  _ratingRepository.DeleteAsync(movieId, userId, token);
    }

    public Task<IEnumerable<MovieRating>> GetRattingsForUserAsync(Guid userId, CancellationToken token = default)
    {
        return _ratingRepository.GetUserRatingsAsync(userId, token);
    }
}