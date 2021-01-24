    services.AddAuthentication(options =>
    {
        options.DefaultChallengeScheme = MicrosoftAccountDefaults.AuthenticationScheme;
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    })
    .AddCookie(option =>
    {
        option.Cookie.Name = ".myAuth"; //optional setting
    })
    .AddMicrosoftAccount(microsoftOptions =>
    {
        microsoftOptions.ClientId = Configuration["Authentication:AppId"];
        microsoftOptions.ClientSecret = Configuration["Authentication:Key"];
    });
