namespace Auth.Api.Configurations;

using System.Text;
using Auth.Shared;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

public static class AuthenticationConfiguration
{
    public static void ConfigureAuthentication(this IServiceCollection services)
    {
        AuthenticationBuilder authenticationBuilder = services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        });

        authenticationBuilder.ConfigureJwtBearer();
    }

    private static void ConfigureJwtBearer(this AuthenticationBuilder authenticationBuilder)
    {
        byte[] key = Encoding.ASCII.GetBytes(Settings.Secret);
        authenticationBuilder.AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
    }
}