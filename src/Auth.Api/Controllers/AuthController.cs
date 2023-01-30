namespace Auth.Api.Controllers;

using Auth.Domain.User.Models;
using Auth.Domain.User.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("v1/auth")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
    private readonly IUserService _userService;

    public AuthController(ILogger<AuthController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpPost]
    [Route("login")]
    [AllowAnonymous]
    public async Task<ActionResult<dynamic>> Authenticate([FromBody] User user)
    {
        return await _userService.AuthenticateUser(user);
    }

    [HttpGet]
    [Authorize]
    [Route("authenticated")]
    public string Authenticated() => String.Format("Authenticated - {0}", User?.Identity?.Name);
}