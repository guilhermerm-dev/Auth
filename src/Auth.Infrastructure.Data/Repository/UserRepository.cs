using Auth.Domain.User.Models;
using Auth.Domain.User.Repository;

namespace Auth.Infrastructure.Data.Repository;

public class UserRepository : IUserRepository
{
    private readonly IList<User> _users;

    public UserRepository()
    {
        _users = new List<User>();
        _users.Add(new User { Id = 1, Username = "guilhermemendes", Password = "fkp12q@", Role = "manager" });
        _users.Add(new User { Id = 2, Username = "leticiamendes", Password = "fkp12q@", Role = "employee" });
    }

    public async Task<User> Get(string username, string password)
    {
        return await Task.Run(() =>
         {
             return _users.Where(x => x.Username.ToLower().Equals(username.ToLower())
                      && x.Password.Equals(password.ToLower()))
                      .FirstOrDefault();
         });
    }
}