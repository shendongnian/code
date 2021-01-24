    public void SignIn(User user, IList<string> roleNames)
    {
        IList<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Sid, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.GivenName, user.FirstName),
            new Claim(ClaimTypes.Surname, user.LastName),
        };
    
        foreach (string roleName in roleNames)
        {
            claims.Add(new Claim(ClaimTypes.Role, roleName));
        }
    
        ClaimsIdentity identity = new ClaimsIdentity(claims, AuthenticationType);
    
        IOwinContext context = _context.Request.GetOwinContext();
        IAuthenticationManager authenticationManager = context.Authentication;
    
        authenticationManager.SignIn(identity);
    }
