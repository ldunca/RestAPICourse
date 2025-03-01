using FluentValidation;
using Movies.Application.Models;
using Movies.Application.Repository;

namespace Movies.Application.Services;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;
    private readonly IValidator<Movie> _movieValidator;

    public MovieService(IMovieRepository movieRepository, IValidator<Movie> movieValidator)
    {
        _movieRepository = movieRepository;
        _movieValidator = movieValidator;
    }
    
    public async Task<bool> CreateMovieAsync(Movie movie, CancellationToken token = default)
    {
        await _movieValidator.ValidateAndThrowAsync(movie, token);
        
        return await _movieRepository.CreateMovieAsync(movie, token);
    }

    public Task<IEnumerable<Movie>> GetAllAsync(Guid? userId, CancellationToken token = default)
    {
        return _movieRepository.GetAllAsync(userId, token);
    }

    public Task<Movie?> GetByIdAsync(Guid id, Guid? userId, CancellationToken token = default)
    {
        return _movieRepository.GetByIdAsync(id, userId, token);
    }

    public Task<Movie?> GetBySlugAsync(string slug, Guid? userId, CancellationToken token = default)
    {
        return _movieRepository.GetBySlugAsync(slug, userId, token);
    }

    public async Task<Movie?> UpdateAsync(Movie movie, Guid? userId, CancellationToken token = default)
    {
        await _movieValidator.ValidateAndThrowAsync(movie, token);
        var movieExists = await _movieRepository.ExistsByIdAsync(movie.Id, token);
        if (!movieExists)
        {
            return null;
        }

        await _movieRepository.UpdateAsync(movie, token);
        
        
        return movie;
    }

    public Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default)
    {
        return _movieRepository.DeleteByIdAsync(id, token);
    }
}