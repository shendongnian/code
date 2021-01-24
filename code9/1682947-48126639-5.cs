    [AllowAnonymous]
    [HttpPost(nameof(ExternalLogin))]
    public IActionResult ExternalLogin(ExternalLoginModel model)
    {
        if (model == null || !ModelState.IsValid)
        {
            return null;
        }
        var properties = new AuthenticationProperties { RedirectUri = _authenticationAppSettings.External.RedirectUri };
        return Challenge(properties, model.Provider);
    }
    [AllowAnonymous]
    [HttpGet(nameof(ExternalLoginCallback))]
    public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
    {
        //Here we can retrieve the claims
        var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    
        return null;
    }
