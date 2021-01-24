    RedirectToIdentityProvider = ctx => {...},
    SecurityTokenValidated = (context) =>
    {
        string userID = context.AuthenticationTicket.Identity.FindFirst(ClaimTypes.NameIdentifier).Value;
        
        // Here you can retrieve information from Database. Let's say you get r.Group_ID.
    
        var role = r.Group_ID;
    
        // You can now add it to Identity and no need to use session.
    
        Claim roleClaim = new Claim(
            "http://nomatterwhatyouput/role",
            role,
            ClaimValueTypes.[RoleType],
            "LocalAuthority");
        context.AuthenticationTicket.Identity.AddClaim(roleClaim);
    
        // Do same for all values you have. Remember to set unique claim URL for each value.
    
        return Task.CompletedTask;
    },
