    var isAdvanced= "1";	
    	
    var identity = (ClaimsIdentity)User.Identity;
    
    // check if claim exist or not.
    var existingClaim = identity.FindFirst("IsAdvanced");
    if (existingClaim != null)
    	identity.RemoveClaim(existingClaim);
    
    // add/update claim value.
    identity.AddClaim(new Claim("IsAdvanced", isAdvanced));
    
    IOwinContext context = Request.GetOwinContext();
    
    var authenticationContext = await context.Authentication.AuthenticateAsync(DefaultAuthenticationTypes.ExternalCookie);
    
    if (authenticationContext != null)
    {
        authenticationManager.AuthenticationResponseGrant = new AuthenticationResponseGrant(identity,authenticationContext.Properties);
    }
