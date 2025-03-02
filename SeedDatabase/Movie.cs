namespace SeedDatabase;

public class Movie
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Slug { get; set; }
    public required int YearOfRelease { get; set; }
    public IEnumerable<string> Genres { get; set; } = new List<string>();
}