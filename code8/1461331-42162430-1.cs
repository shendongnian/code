      var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                info = await AuthenticationManager_GetExternalLoginInfoAsync_Workaround();
                if (info == null)
                {
                    return RedirectToAction(nameof(Login));
                }
            }
