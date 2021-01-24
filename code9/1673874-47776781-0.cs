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
            // Only one identity supported by the current implementation of IdentityServer4
            if (ticketReceivedContext.Principal.Identities.Count() != 1) throw new InvalidOperationException("only a single identity supported");
            var oldIdentity = ticketReceivedContext.Principal.Identity as ClaimsIdentity;
            var oldPrincipal = ticketReceivedContext.Principal;
            var claims = new List<Claim>();
            claims.AddRange(oldPrincipal.Claims);
            claims.Add(new Claim("sub", ticketReceivedContext.Principal.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn")));
            var newIdentity = new ClaimsIdentity(claims,oldIdentity.AuthenticationType, oldIdentity.NameClaimType, oldIdentity.RoleClaimType);
            newIdentity.Actor = oldIdentity.Actor;
            ticketReceivedContext.Principal = new ClaimsPrincipal(newIdentity);
        }
