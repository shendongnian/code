    public override Task ValidateIdentity(CookieValidateIdentityContext context) {
        Claim simpleClaim = context.Identity.FindFirst("SIMPLECOUNT");
        if (simpleClaim != null) {
            Trace.WriteLine($"SIMPLECOUNT: {simpleClaim.Value}");
            if (context.Identity.TryRemoveClaim(simpleClaim)) {
                var newIdentity = new ClaimsIdentity(context.Identity);
                int newcount = 1 + int.Parse(simpleClaim.Value);
                newIdentity.AddClaim(new Claim("SIMPLECOUNT", newcount.ToString()));
                context.Request.Context.Authentication.SignIn(newIdentity);
            }               
        }
        return Task.FromResult<object>(null);
    }
