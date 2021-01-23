    app.UseCookieAuthentication(new CookieAuthenticationOptions
    {
         AuthenticationScheme = "Cookies",
         Events = new CookieAuthenticationEvents()
         {
             OnSigningIn = async (context) =>
             {
                 ClaimsIdentity identity = (ClaimsIdentity)context.Principal.Identity;
                 // get claims from user profile
                 // add these claims into identity
             }
         }
    });
