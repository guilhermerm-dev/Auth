namespace Auth.Domain.Token.Services;

using Auth.Domain.Token.Models;
using Auth.Domain.User.Models;

public interface ITokenService
{
    AccessToken GenerateToken(User user);
}