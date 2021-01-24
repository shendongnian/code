    public IActionResult LoginWithTwich(string returnUrl = null)
        {
            var authProperties = _signInManager.ConfigureExternalAuthenticationProperties("Twitch", returnUrl);
            return Challenge(authProperties, "Twitch");
        }
