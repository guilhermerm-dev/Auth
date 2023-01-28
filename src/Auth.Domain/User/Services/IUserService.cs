namespace Auth.Domain.User.Services;

using Auth.Domain.Token.Models;
using Auth.Domain.User.Models;

public interface IUserService
{
    Task<AccessToken> AuthenticateUser(User user);
}