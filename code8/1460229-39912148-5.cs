        app.UseOpenIdConnectAuthentication(new OpenIdConnectOptions
        {
            AuthenticationScheme = "oidc",
            SignInScheme = "Cookies",
            Authority = Configuration.GetSection("IdentityServer").GetValue<string>("Authority"),
            RequireHttpsMetadata = false,
            ClientId = "RateAdminApp",
            Events = new OpenIdConnectEvents
            {
               OnTicketReceived = e =>
               {
                   // get claims from user profile
                   // add claims into e.Ticket.Principal
                   e.Ticket = new AuthenticationTicket(e.Ticket.Principal, e.Ticket.Properties, e.Ticket.AuthenticationScheme);
                   return Task.CompletedTask;
                }
            }
        });
