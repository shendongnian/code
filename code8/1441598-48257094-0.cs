      var claimsIdentity = await AuthenticationManager.GetExternalIdentityAsync(DefaultAuthenticationTypes.ExternalCookie);
                if (claimsIdentity != null)
                {
                    // Retrieve the existing claims for the user and add the FacebookAccessTokenClaim
                    var currentClaims = await UserManager.GetClaimsAsync(user.Id);
                    var facebookAccessToken = claimsIdentity.FindAll("FacebookAccessToken").First();
                    if (currentClaims.Count() <= 0)
                    {
                        await UserManager.AddClaimAsync(user.Id, facebookAccessToken);
                    }
