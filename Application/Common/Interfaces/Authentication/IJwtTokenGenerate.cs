namespace Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerate
{
    string GenerateToken(Guid id, string firstName, string lastName);
}