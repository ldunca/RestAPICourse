namespace Movies.Contracts.Requests;

public class CreateRatingRequest
{
    public required Guid MovieId { get; init; }
    public required int Rating { get; init; }
}