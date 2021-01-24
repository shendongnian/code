    [HttpPost]
    [AllowAnonymous]
    public ActionResult Index(string userID, string password)
    {
        if(CheckUserCredentialsAgainstDB(userID, password))
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, userID),
                new Claim(ClaimTypes.Role, "therole")
            };
            var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie); // create a new user identity
            
            var auth = Request.GetOwinContext().Authentication;
            auth.SignIn(new AuthenticationProperties
            {
                IsPersistent = false // set to true if you want `remember me` feature
            }, identity);
            
            // redirect the user somewhere
        }
        // notify the user of failure
    }
