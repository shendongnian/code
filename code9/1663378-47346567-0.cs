    app.UseOpenIdConnectAuthentication(new OpenIdConnectOptions
    {
        ClientId = Configuration["AzureAD:ClientId"],
        Authority = string.Format(CultureInfo.InvariantCulture, Configuration["AzureAd:AadInstance"], "common", "/v2.0"),
        ResponseType = OpenIdConnectResponseType.IdToken,
        PostLogoutRedirectUri = Configuration["AzureAd:PostLogoutRedirectUri"],
        Events = new OpenIdConnectEvents
        {
            OnRemoteFailure = RemoteFailure,
            OnTokenValidated = TokenValidated
        },
        TokenValidationParameters = new TokenValidationParameters
        {
            // Instead of using the default validation (validating against
            // a single issuer value, as we do in line of business apps), 
            // we inject our own multitenant validation logic
            ValidateIssuer = false,
            NameClaimType = "name"
        }
    });
    private Task TokenValidated(TokenValidatedContext context)
    {
        /* ---------------------
        // Replace this with your logic to validate the issuer/tenant
            ---------------------       
        // Retriever caller data from the incoming principal
        string issuer = context.SecurityToken.Issuer;
        string subject = context.SecurityToken.Subject;
        string tenantID = context.Ticket.Principal.FindFirst("http://schemas.microsoft.com/identity/claims/tenantid").Value;
        // Build a dictionary of approved tenants
        IEnumerable<string> approvedTenantIds = new List<string>
        {
            "<Your tenantID>",
            "9188040d-6c67-4c5b-b112-36a304b66dad" // MSA Tenant
        };
        o
        if (!approvedTenantIds.Contains(tenantID))
            throw new SecurityTokenValidationException();
            --------------------- */
        var claimsIdentity=(ClaimsIdentity)context.Ticket.Principal.Identity;
        //add your custom claims here
        claimsIdentity.AddClaim(new Claim("test", "helloworld!!!"));
        return Task.FromResult(0);
    }
