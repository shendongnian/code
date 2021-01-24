        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            //... SignInManager<User> _signInManager; declared before
            ExternalLoginInfo info = await _signInManager.GetExternalLoginInfoAsync();
            SignInResult signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);
            string email = info.Principal.FindFirstValue(ClaimTypes.Email);
            string firstName = info.Principal.FindFirstValue(ClaimTypes.GivenName);
            string lastName = info.Principal.FindFirstValue(ClaimTypes.Surname);
            // profile claims
            string picture = info.Principal.FindFirstValue("picture");
            string firstName = info.Principal.FindFirstValue("given_name");
            string lastName = info.Principal.FindFirstValue("family_name");
        }
