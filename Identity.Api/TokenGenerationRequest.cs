namespace Identity.Api;

public class TokenGenerationRequest
{
    public Guid UserId { get; init; }
    
    public required string Email { get; init; }

    public required Dictionary<string, object> CustomClaims { get; init; } = new();
}