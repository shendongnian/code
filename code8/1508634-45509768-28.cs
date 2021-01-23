            // Configure the OWIN pipeline to use cookie auth.
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                Events = new CookieAuthenticationEvents
                {
                    OnValidatePrincipal = OnValidatePrincipal
                },
            });
