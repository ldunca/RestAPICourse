using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.Services;
using Movies.Contracts.Requests;

namespace Movies.API.Controllers;

public class RatingsController : ControllerBase
{
    private readonly IRatingService _ratingService;

    public RatingsController(IRatingService ratingService)
    {
        _ratingService = ratingService;
    }

    [Authorize]
    [HttpPost(ApiEndpoints.Movies.Rate)]
    public async Task<IActionResult> RateMovie(
        [FromRoute] Guid id,
        [FromBody] CreateRatingRequest request,
        CancellationToken token)
    {
        var userId = HttpContext.GetUserId();
        var result = await _ratingService.RateMovieAsync(id, request.Rating, userId!.Value, token);
        return result ? Ok() : NotFound();
    }
}