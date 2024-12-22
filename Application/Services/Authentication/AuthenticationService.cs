using Application.Common.Interfaces.Authentication;
using Application.Common.Persistence;
using Domain.Entities;

namespace Application.Services.Authentication;

public class AuthenticationService(
    IJwtTokenGenerate jwtTokenGenerate,
    IUserRepository userRepository) : IAuthenticationService
{
    public AuthenticationResult Login(string email, string password)
    {
        if (userRepository.GetByEmail(email) is not User user)
        {
            throw new Exception("Invalid email");
        }

        if (user.Password != password)
        {
            throw new Exception("Invalid password");
        }
        
        var token = jwtTokenGenerate.GenerateToken(user);
        
        return new AuthenticationResult(user, token);
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        if (userRepository.GetByEmail(email) != null)
        {
            throw new Exception("User with given email already exists");
        }

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };
        
        userRepository.Add(user);
        
        var token = jwtTokenGenerate.GenerateToken(user);
        
        return new AuthenticationResult(user, token);
    }
}