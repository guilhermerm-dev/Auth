using Auth.Infrastructure.IoC;

namespace Auth.Api.Configurations;

public static class DependencyInjectionConfiguration
{
    public static void ConfigureDependencyInjection(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        DependencyInjectionBootstrapper.RegisterDependencyInjectionContainer(services);
    }
}