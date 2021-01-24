    services.AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
    }).AddCookie(options => new CookieAuthenticationOptions
    {
        //AuthenticationScheme = "Cookies", // Removed in 2.0
        ExpireTimeSpan = TimeSpan.FromHours(12),
        SlidingExpiration = false,
        Cookie = new CookieBuilder
        {
            Path = CookiePath,
            Name = "MyCookie"
        }
    })
    .AddOpenIdConnect(options => SetOpenIdConnectOptions(options));
    private void SetOpenIdConnectOptions(OpenIdConnectOptions options)
    {
        options.ClientId = Configuration["OpenIdSettings:ClientId"];
        options.ClientSecret = Configuration["OpenIdSettings:ClientSecret"];
        options.Authority = Configuration["OpenIdSettings:Authority"];
        options.MetadataAddress = $"{Configuration["OpenIdSettings:Authority"]}/.well-known/openid-configuration";
        options.GetClaimsFromUserInfoEndpoint = true;
        options.SignInScheme = "Cookies";
        options.ResponseType = OpenIdConnectResponseType.IdToken;
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            // This sets the value of User.Identity.Name to users AD username
            NameClaimType = IdentityClaimTypes.WindowsAccountName,
            RoleClaimType = IdentityClaimTypes.Role,
            AuthenticationType = "Cookies",
            ValidateIssuer = false
        };
        // Scopes needed by application
        options.Scope.Add("openid");
        options.Scope.Add("profile");
        options.Scope.Add("roles");
    }
