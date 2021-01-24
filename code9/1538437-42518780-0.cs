    var claims = new List<Claim>();
    claims.Add(new Claim(ClaimTypes.NameIdentifier, <userid>));
    claims.Add(new Claim(ClaimTypes.Name, <name>));
    var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
    
        AuthenticationManager.SignIn(new AuthenticationProperties()
        {
            AllowRefresh = true,
            IsPersistent = isPersistent,
            ExpiresUtc = DateTime.UtcNow.AddDays(7)
        }, identity);
