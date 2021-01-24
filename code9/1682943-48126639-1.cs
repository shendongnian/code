    [AllowAnonymous]
    [HttpGet(nameof(ExternalLoginCallback))]
    public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
    {
        //Here we can retrieve the claims
        var result = await HttpContext.AuthenticateAsync("YourCustomScheme");
    
        return null;
    }
