    public void Configure(IApplicationBuilder app, IHostingEnvironment env, IAntiforgery antiforgery)
        {
            // XSRF config
            app.Use(next => context =>
            {
                string path = context.Request.Path.Value;
                if (
                    string.Equals(path, "/", StringComparison.OrdinalIgnoreCase) ||
                    path.StartsWith("/Login",StringComparison.OrdinalIgnoreCase))
                {
                    // The request token can be sent as a JavaScript-readable cookie, 
                    // and Angular uses it by default.
                    var tokens = antiforgery.GetAndStoreTokens(context);
                    context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken,
                                                    new CookieOptions() { HttpOnly = false });
                }
                return next(context);
            });
            // End XSRF config
