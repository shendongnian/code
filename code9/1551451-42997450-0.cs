    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<ContentResult> Login(string username, string password)
    {
    	if(username!="ADMIN" || password!="123")
    		return new ContentResult { Content = "" };
    
    	ClaimsPrincipal principal = new ClaimsPrincipal(new ClaimsIdentity(
    		new List<Claim>{
    			new Claim(ClaimTypes.Name, username)
    		},
    		"cookies/ADMIN"));
    
    	await HttpContext.Authentication.SignInAsync(AdminAuthSchemeName, principal);
    
    	return new ContentResult { Content = username };
    }
