    app.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
    {
        Authority = "http://localhost:5000",
        RequireHttpsMetadata = false,
        ApiName = "api1",
        Events = new OpenIdConnectEvents() 
        {
            OnMessageReceived = async context =>
            {
                //example of a "before" event hook
            }
            OnTokenValidated = async context =>
            {
                //example of an "after" event hook
                var claimsIdentity = context.Ticket.Principal.Identity as ClaimsIdentity;
                if (claimsIdentity != null)
                {
                    // Get the user's ID
                    string userId = claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
                }
            }
         }
    });
