using Application.Common.Persistence;
using Domain.Entities;

namespace Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> Users = [];
    public void Add(User user)
    {
        Users.Add(user);
    }

    public User? GetByEmail(string email)
    {
        return Users.FirstOrDefault(u => u.Email == email);
    }
}