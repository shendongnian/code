    [HttpPost("~/connect/token")]
    [Produces("application/json")]
    public IActionResult Exchange(OpenIdConnectRequest request)
    {
        if (request.IsPasswordGrantType())
        {
            // ...
        }
        else if (request.GrantType == "urn:ietf:params:oauth:grant-type:google_identity_token")
        {
            // Reject the request if the "assertion" parameter is missing.
            if (string.IsNullOrEmpty(request.Assertion))
            {
                return BadRequest(new OpenIdConnectResponse
                {
                    Error = OpenIdConnectConstants.Errors.InvalidRequest,
                    ErrorDescription = "The mandatory 'assertion' parameter was missing."
                });
            }
    
            // Create a new ClaimsIdentity containing the claims that
            // will be used to create an id_token and/or an access token.
            var identity = new ClaimsIdentity(OpenIdConnectServerDefaults.AuthenticationScheme);
    
            // Manually validate the identity token issued by Google,
            // including the issuer, the signature and the audience.
            // Then, copy the claims you need to the "identity" instance.
    
            // Create a new authentication ticket holding the user identity.
            var ticket = new AuthenticationTicket(
                new ClaimsPrincipal(identity),
                new AuthenticationProperties(),
                OpenIdConnectServerDefaults.AuthenticationScheme);
    
            ticket.SetScopes(
                OpenIdConnectConstants.Scopes.OpenId,
                OpenIdConnectConstants.Scopes.OfflineAccess);
    
            return SignIn(ticket.Principal, ticket.Properties, ticket.AuthenticationScheme);
        }
    
        return BadRequest(new OpenIdConnectResponse
        {
            Error = OpenIdConnectConstants.Errors.UnsupportedGrantType,
            ErrorDescription = "The specified grant type is not supported."
        });
    }
