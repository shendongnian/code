    public void ConfigureServices(IServiceCollection services)
    {
        // Add MVC services to the services container.
        services.AddMvc();
        // Add Authentication services.
        services.AddAuthentication(sharedOptions =>
        {
            sharedOptions.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            sharedOptions.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        })
                
            // Configure the OWIN pipeline to use OpenID Connect auth.
            .AddOpenIdConnect(option =>
            {
                option.ClientId = Configuration["AzureAD:ClientId"];
                option.Authority = String.Format(Configuration["AzureAd:AadInstance"], Configuration["AzureAd:Tenant"]);
                option.SignedOutRedirectUri = Configuration["AzureAd:PostLogoutRedirectUri"];
                option.Events = new OpenIdConnectEvents
                {
                    OnRemoteFailure = OnAuthenticationFailed,
                };
            })// Configure the OWIN pipeline to use cookie auth.
            .AddCookie(op => {
                op.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                op.LoginPath = "/Account/Login";
                op.Events.OnRedirectToLogin =async(context) =>
                    {   
                        //Clean the session values
                        context.HttpContext.Session.Clear();
                        //Sign-out to AAD
                        await context.HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
                        //Redirect to op.LoginPath ("/Account/Login") for logging again
                        context.Response.Redirect(context.RedirectUri);
                    };
            });
        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(20);
            options.CookieHttpOnly = true;
        });
    }
