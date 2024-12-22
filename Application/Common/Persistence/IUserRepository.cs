using Domain.Entities;

namespace Application.Common.Persistence;

public interface IUserRepository
{
    void Add(User user);
    User? GetByEmail(string email);
}