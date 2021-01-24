    public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
    {
        // ...
        var identity = new ClaimsIdentity(context.Options.AuthenticationType);
        if (Membership.ValidateUser(username, password))
        {          
            identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
            identity.AddClaim(new Claim(ClaimTypes.Name, username));
            identity.AddClaim(new Claim("oauth-client", context.ClientId));
            context.Validated(identity);
        }
        else
        {
            context.SetError("Login Field", "Error username or password");
        }
    }
