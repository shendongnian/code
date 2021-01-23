      public void SignIn(bool? signedOut)
        {
            // Send an OpenID Connect sign-in request.
            if (!Request.IsAuthenticated)
            {
                // If the user is currently logged into another directory, log them out then attempt to
                // reauthenticate under this directory
                if (signedOut == null || signedOut == false)
                {
                    HttpContext.GetOwinContext().Authentication.SignOut(
                new AuthenticationProperties { RedirectUri = Url.Action("SignIn", "Account", routeValues: new { signedOut = true }, protocol: Request.Url.Scheme) },
                OpenIdConnectAuthenticationDefaults.AuthenticationType, CookieAuthenticationDefaults.AuthenticationType);
                }
                else
                {
                    HttpContext.GetOwinContext().Authentication.Challenge(new AuthenticationProperties { RedirectUri = "/" },
                        OpenIdConnectAuthenticationDefaults.AuthenticationType);
                }
            }
        }
