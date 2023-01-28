using Auth.Domain.Token.Services;
using Auth.Domain.User.Services;
using Auth.Domain.User.Repository;
using Auth.Infrastructure.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Infrastructure.IoC;

public static class DependencyInjectionBootstrapper
{
    public static void RegisterDependencyInjectionContainer(this IServiceCollection services)
    {
        services.RegisterServices();
        services.RegisterRepositories();
    }

    private static void RegisterServices(this IServiceCollection services)
    {
        services.AddTransient<ITokenService, TokenService>();
        services.AddTransient<IUserService, UserService>();
    }

    private static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
    }
}
