namespace Auth.Domain.Token.Models;

public class AccessToken
{
    public AccessToken(string token, string username, string role)
    {
        Token = token;
        Username = username;
        Role = role;
    }

    public string Token { get; private set; }
    public string Username { get; private set; }
    public string Role { get; private set; }
}