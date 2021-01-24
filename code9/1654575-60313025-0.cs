JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
services.AddAuthentication(options =>
	{
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:4991";
        options.RequireHttpsMetadata = false;
        // name of the API resource
        options.Audience = "api";
    });
services.AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = "oidc";
    })
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddOpenIdConnect("oidc", options =>
    {
        options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.Authority = "https://localhost:4991";
        options.RequireHttpsMetadata = false;
        options.ClientId = "WebApp";
        options.ClientSecret = "secret";
        options.ResponseType = "code id_token";
        options.Scope.Add("api");
        options.SaveTokens = true;
    });
services.AddAuthorization(options =>
{	
    // Add policies for API scope claims
     options.AddPolicy(AuthorizationConsts.ReadPolicy,
        policy => policy.RequireAssertion(context =>
            context.User.HasClaim(c =>
                ((c.Type == AuthorizationConsts.ScopeClaimType && c.Value == AuthorizationConsts.ReadScope)
                || (c.Type == AuthorizationConsts.IdentityProviderClaimType))) && context.User.Identity.IsAuthenticated
        ));
    // No need to add default policy here
});
app.UseAuthentication();
app.UseCookiePolicy();
In the controller, add necessary Authorize attribute
[Authorize(AuthenticationSchemes = AuthorizationConsts.BearerOrCookiesAuthenticationScheme, Policy = AuthorizationConsts.ReadPolicy)]
Here is the helper class
public class AuthorizationConsts
{
    public const string BearerOrCookiesAuthenticationScheme = CookieAuthenticationDefaults.AuthenticationScheme + "," + IdentityServerAuthenticationDefaults.AuthenticationScheme;
    public const string IdentityProviderClaimType = "idp";
    public const string ScopeClaimType = "scope";
    public const string ReadPolicy = "RequireReadPolicy";
    public const string ReadScope = "data:read";
}
