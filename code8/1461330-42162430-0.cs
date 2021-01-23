    private async Task<ExternalLoginInfo> AuthenticationManager_GetExternalLoginInfoAsync_Workaround()
            {
                ExternalLoginInfo loginInfo = null;
                var info = await HttpContext.Authentication.GetAuthenticateInfoAsync(IdentityServerConstants.ExternalCookieAuthenticationScheme);
                var auth = new AuthenticateContext(IdentityServerConstants.ExternalCookieAuthenticationScheme);
                // read external identity from the temporary cookie
                await HttpContext.Authentication.AuthenticateAsync(auth);
    
                if (auth.Principal == null || auth.Properties == null)
                {
                    throw new Exception("External authentication error");
                }
    
                // retrieve claims of the external user
                var claims = auth.Principal.Claims.ToList();
    
    
                // try to determine the unique id of the external user - the most common claim type for that are the sub claim and the NameIdentifier
                // depending on the external provider, some other claim type might be used
                var userIdClaim = claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Subject);
                if (userIdClaim == null)
                {
                    userIdClaim = claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
                }
                if (userIdClaim == null)
                {
                    throw new Exception("Unknown userid");
                }
    
                string userObjectID = auth.Principal.FindFirst(ClaimTypes.NameIdentifier).Value;
                // remove the user id claim from the claims collection and move to the userId property
                // also set the name of the external authentication provider
                claims.Remove(userIdClaim);
                var provider = userIdClaim.Issuer;
                var userId = userIdClaim.Value;
    
                var displayName = auth.Principal.FindFirstValue(ClaimTypes.GivenName);
    
                AuthenticationProperties props = null;
                
    
                loginInfo = new ExternalLoginInfo(auth.Principal, userIdClaim.Issuer, userIdClaim.Value, displayName)         
    
                return loginInfo;
            }
