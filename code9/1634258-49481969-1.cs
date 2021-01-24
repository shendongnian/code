      services.AddAuthentication(
                v =>
                {
                    v.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    v.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                }).
                AddGoogle("Google", googleOptions =>
             {
                 googleOptions.ClientId = "xxx...";
                 googleOptions.ClientSecret = "zzz...";
                 googleOptions.SignInScheme = "ExternalCookie";
                 googleOptions.Events = new OAuthEvents
                 {
                     OnRedirectToAuthorizationEndpoint = context =>
                     {
                         context.Response.Redirect(context.RedirectUri + "&hd=" + System.Net.WebUtility.UrlEncode("gmail.com"));
                         return Task.CompletedTask;
                     }
                 };
     });
