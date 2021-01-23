            // Configure the OWIN pipeline to use cookie auth.
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                ExpireTimeSpan = new TimeSpan(0, 0, 20),
                SlidingExpiration = false,
                Events = new CookieAuthenticationEvents
                {
                    OnValidatePrincipal = OnValidatePrincipal
                },
            });
