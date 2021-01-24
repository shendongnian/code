    [HttpPost]
    [AllowAnonymous]
    public IActionResult ExternalLogin(string provider, string returnUrl = null)
    {
        // Request a redirect to the external login provider.
        var redirectUrl = Url.Action(nameof(ExternalLoginCallback),"Account", new { returnUrl });
        var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
        return Challenge(properties, provider);
    }
