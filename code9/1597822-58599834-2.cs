    var authenticationBuilder = services.AddAuthentication(options =>
    {
        options.DefaultScheme = "Cookies";
        options.DefaultChallengeScheme = "oidc";
    });
    authenticationBuilder.AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
        options.Cookie.Name = "identity_server_mvc";
    });
    authenticationBuilder.AddOpenIdConnect("oidc", options =>
    {
        options.Authority = "{IDENTITY_SERVER_URL}";
        options.ClientId = "mvc";
        options.SaveTokens = true;
        options.SignInScheme = "Cookies";
    });
