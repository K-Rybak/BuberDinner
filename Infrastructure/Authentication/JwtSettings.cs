namespace Infrastructure.Authentication;

public class JwtSettings
{
    public const string SECTION_NAME = "JwtSettings";
        
    public string Issuer { get; init; } = null!;
    public string Audience { get; init; } = null!;
    public string SigningKey { get; init; } = null!;
    public int ExpirationInMinutes { get; init; }
}