    var identity = new ClaimsIdentity(Startup.OAuthOptions.AuthenticationType);
    AuthenticationTicket ticket = new AuthenticationTicket(identity, new AuthenticationProperties());
    var currentUtc = new SystemClock().UtcNow;
    identity.AddClaim(new Claim("device_type", "android/ios/web"));
    
    ticket.Properties.IssuedUtc = currentUtc;
    var expiryInterval = int.Parse("20");
    var access_token = Startup.OAuthOptions.AccessTokenFormat.Protect(ticket);
