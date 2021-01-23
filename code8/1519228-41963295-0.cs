    /// <summary>
    /// Ensures that a back office user is logged in
    /// </summary>
    /// <returns></returns>
    public bool IsAuthenticated()
    {
		bool isAuthenticated = false;
        if (_httpContext.User.Identity.IsAuthenticated)
        {
			// user is already authenticated in umbraco.
            if (_httpContext.GetCurrentIdentity(false) != null)
				isAuthenticated = true;
            // check user in umbraco, and if found set as authenticated.
            else
            {
				// active directory username.
                var userName = _httpContext.User.Identity.Name.Replace("MOD\\", string.Empty);
                var result = SignInManager.PasswordSignInAsync(userName, string.Empty, isPersistent: true, shouldLockout: true).Result;
                if (result == SignInStatus.Success)
                {
					// log this user in backoffice.
                    var user = GetBackOfficeUser(_httpContext.User.Identity.Name.Replace("MOD\\", string.Empty));
                    PerformLogin(user.Id);
                    // and set as authenticated.
                    isAuthenticated = true;
                }
            }
        }
        //return _httpContext.User.Identity.IsAuthenticated && _httpContext.GetCurrentIdentity(false) != null;
        return isAuthenticated;
	}
