    var identity = new ClaimsIdentity(new[]
    {
        new Claim(ClaimTypes.Name, UserName),
        // add another claims (e.g. for each role)
    },
    CookieAuthenticationDefaults.AuthenticationType);
    Context.OwinContext.Authentication.SignIn(identity);
