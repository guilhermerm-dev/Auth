namespace Auth.Domain.Token.Services;

using Auth.Domain.Token.Models;
using Auth.Domain.User.Models;
using Auth.Shared;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

public class TokenService : ITokenService
{
    private const int _HOURS_TO_EXPIRE_TOKEN = 2;

    public AccessToken GenerateToken(User user)
    {
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        byte[] key = Encoding.ASCII.GetBytes(Settings.Secret);
        SecurityTokenDescriptor tokenSpecificationDescriptor = DescribeTokenSpecification(user, key);
        SecurityToken securityToken = tokenHandler.CreateToken(tokenSpecificationDescriptor);
        string token = tokenHandler.WriteToken(securityToken);
        return new AccessToken(token, user.Username, user.Role);
    }

    private SecurityTokenDescriptor DescribeTokenSpecification(User user, byte[] key)
    {
        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = ConfigureClaimsIdentity(user),
            Expires = DateTime.UtcNow.AddHours(_HOURS_TO_EXPIRE_TOKEN),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        return tokenDescriptor;
    }

    private ClaimsIdentity ConfigureClaimsIdentity(User user)
    {
        ClaimsIdentity claimsIdentity = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                });
        return claimsIdentity;
    }
}