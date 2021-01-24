    // Note: while ASP.NET Core Identity uses the legacy WS-Federation claims (exposed by the ClaimTypes class),
    // OpenIddict uses the newer JWT claims defined by the OpenID Connect specification. To ensure the mandatory
    // subject claim is correctly populated (and avoid an InvalidOperationException), it's manually added here.
    if (string.IsNullOrEmpty(principal.FindFirstValue(OpenIdConnectConstants.Claims.Subject)))
    {
        identity.AddClaim(new Claim(OpenIdConnectConstants.Claims.Subject, await _userManager.GetUserIdAsync(user)));
    }
