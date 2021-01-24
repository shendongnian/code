    public async Task<IHttpActionResult> GetExternalLoginAsync(BaseApiController controller, IIdentity identity, string provider, string error = null)
    {
        // If we have an error, return it
        if (error != null) return controller.BadRequest(Uri.EscapeDataString(error));
        // If the current user is not authenticated
        if (!identity.IsAuthenticated) return new ChallengeResult(provider, controller);
        // Validate the client and the redirct url
        var redirectUri = await ValidateClientAndRedirectUriAsync(controller.Request);
        // If we have no validated
        if (!string.IsNullOrWhiteSpace(redirectUri)) return controller.BadRequest(redirectUri);
        // Get the current users external login
        var externalLogin = GetExternalLoginDataFromIdentity(identity as ClaimsIdentity);
        // If the current user has no external logins, throw an error
        if (externalLogin == null) return controller.InternalServerError();
        // if the login provider doesn't match the one specificed
        if (externalLogin.LoginProvider != provider)
        {
            // Sign the user out
            AuthenticationManager(controller.Request).SignOut(DefaultAuthenticationTypes.ExternalCookie);
            // Challenge the result
            return new ChallengeResult(provider, controller);
        }
        // Get the user
        var user = await FindAsync(new UserLoginInfo(externalLogin.LoginProvider, externalLogin.ProviderKey));
        // Have they registered
        bool hasRegistered = user != null;
        // Update our url
        redirectUri += $"{redirectUri}#external_access_token={externalLogin.ExternalAccessToken}&provider={externalLogin.LoginProvider}&haslocalaccount={hasRegistered.ToString()}&external_user_name={externalLogin.UserName}";
        // Return our url
        return controller.Redirect(redirectUri);
    }
