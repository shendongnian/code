	[HttpGet("name/{name}")]
	[AllowAnonymous]
    public async Task<IActionResult> Get(string name)
    {
        var activity = Repo.GetCommandLineActivity(name);
        if (activity == null)
        {
            return NotFound();
        }
		// based on the way your authentication is configured in services.AddAuthentication(),
		// this can be omitted (in which case, the default authenticate scheme will be used) 
		var authenticationScheme = CookieAuthenticationDefaults.AuthenticationScheme;
		var auth  = await HttpContext.AuthenticateAsync(authenticationScheme);
        if (auth.Succeeded)
        {
			// CAUTION: HttpContext.User will STILL be null
			var user = auth.Principal;
            return Ok(activity);
        }
        return Unauthorized();
    }
