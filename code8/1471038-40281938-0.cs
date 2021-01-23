    [AllowAnonymous]
    [HttpGet]
    public ActionResult Login()
    {
        . . . .
   
        string userName = (string)Session["UserName"];
        string[] userRoles = (string[])Session["UserRoles"];
       
        ClaimsIdentity identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
    
        identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userName));
    
        userRoles.ToList().ForEach((role) => identity.AddClaim(new Claim(ClaimTypes.Role, role)));
        identity.AddClaim(new Claim(ClaimTypes.Name, userName));
        AuthenticationManager.SignIn(identity);
        . . . .
    }
