    public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null)
        {
            ExternalLoginInfo info = await _signInManager.GetExternalLoginInfoAsync();
            //to sign the user in if there's a local account associated to the login provider
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);
            if (!result.Succeeded)
            {
                return RedirectToAction("ConfirmTwitchLogin", new { ReturnUrl = returnUrl });
            }
            if (string.IsNullOrEmpty(returnUrl))
            {
                return Redirect("~/");
            }
            else
            {
                return RedirectToLocal(returnUrl);
            }
        }
