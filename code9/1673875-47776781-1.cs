    services.AddAuthentication()
                    .AddWsFederation("WsFederation", options =>
                    {
                        options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                        options.Wtrealm = realm;
                        options.MetadataAddress = metadata;
                        options.Events.OnTicketReceived += OnTicketReceived;
                    })
    
    /* some more code inbetween */
        /// <summary>
        /// Transform the UPN-claim to the sub-claim to be compatible with IdentityServer4
        /// </summary>
        private async Task OnTicketReceived(TicketReceivedContext ticketReceivedContext)
        {
            var identity = ticketReceivedContext.Principal.Identities.First();
            identity.AddClaim(new Claim("sub", ticketReceivedContext.Principal.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")));
        }
