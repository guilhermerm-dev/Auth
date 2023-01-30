namespace Auth.Domain.User.Services;

using Auth.Domain.Token.Models;
using Auth.Domain.Token.Services;
using Auth.Domain.User.Repository;
using Auth.Domain.User.Models;

public class UserService : IUserService
{
    private readonly ITokenService _tokenService;
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    public async Task<AccessToken> AuthenticateUser(User userData)
    {
        User user = await _userRepository.Get(userData.Username, userData.Password);
        AccessToken acessToken = _tokenService.GenerateToken(user);
        return acessToken;
    }
}