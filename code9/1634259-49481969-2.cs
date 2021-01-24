     public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
           var info = await HttpContext.AuthenticateAsync("ExternalCookie");
            //Sign in to local cookie and logout of external cookie
            await HttpContext.SignInAsync("MainCookie", info.Principal);
            await HttpContext.SignOutAsync("ExternalCookie");
            //ExternalCookie will be deleted at this point. 
            return RedirectToLocal(returnUrl);
        }
