    public IActionResult LoginWithTwich(string returnUrl = null)
        {
            var authProperties = new AuthenticationProperties
            {
                RedirectUri = Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }),
                Items = { new KeyValuePair<string, string>("LoginProvider", "Twitch") }
            };
            return Challenge(authProperties, "Twitch");
        }
