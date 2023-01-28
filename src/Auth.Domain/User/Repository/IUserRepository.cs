namespace Auth.Domain.User.Repository;

using Auth.Domain.User.Models;

public interface IUserRepository
{
    Task<User> Get(string username, string password);
}