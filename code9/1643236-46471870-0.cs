    // Check the identity
    if (identity.IsAuthenticated)
    {
        var ticket = new AuthenticationTicket(new ClaimsPrincipal(identity), null, "exttoken");
        var result = AuthenticateResult.Success(ticket);
        Request.HttpContext.Items["auth"] = authRepo;
        return result;
    }
