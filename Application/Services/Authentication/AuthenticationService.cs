using Application.Common.Interfaces.Authentication;

namespace Application.Services.Authentication;

public class AuthenticationService(IJwtTokenGenerate jwtTokenGenerate) : IAuthenticationService
{
    public AuthenticationResult Login(string email, string password)
    {
        //var token = _jwtTokenGenerate.GenerateToken()
        return new AuthenticationResult(
            Guid.NewGuid(),
            "FirstName",
            "LastName",
            email,
            "Token");
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        var token = jwtTokenGenerate.GenerateToken(Guid.NewGuid(), firstName, lastName);
        
        return new AuthenticationResult(
            Guid.NewGuid(),
            firstName,
            lastName,
            email,
            token);
    }
}