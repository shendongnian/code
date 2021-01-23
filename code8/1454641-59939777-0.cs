c#
public void ConfigureServices(IServiceCollection services)
{
    // ...
    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _config.AuthenticationSettings.TokenAuthority,
                ValidAudience = _config.AuthenticationSettings.TokenAuthority,
                LifetimeValidator = TokenLifetimeValidator.Validate,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_config.AuthenticationSettings.SecurityKey))
            };
        });
    // ...
}
And so I also made my own version of the token validator in @tkd_aj's [answer above][1] and threw it in a static class:
c#
public static class TokenLifetimeValidator
{
    public static bool Validate(
        DateTime? notBefore,
        DateTime? expires,
        SecurityToken tokenToValidate,
        TokenValidationParameters @param
    ) {
        return (expires != null && expires > DateTime.UtcNow);
    }
}
[1]: https://stackoverflow.com/a/45886796/3443552
[2]: https://docs.microsoft.com/en-us/dotnet/api/system.identitymodel.tokens.inmemorysymmetricsecuritykey?view=netframework-4.8&viewFallbackFrom=netcore-3.1
