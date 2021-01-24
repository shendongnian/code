            /// <summary>
            ///     Gets details of a single <see cref="User" /> Graph.
            /// </summary>
            /// <returns>A view with the details of a single <see cref="User" />.</returns>
            public async Task<ActionResult> Details(string objectId)
            {
                User user = null;
                try
                {
                    ActiveDirectoryClient client = AuthenticationHelper.GetActiveDirectoryClient();
                    user = (User) await client.Users.GetByObjectId(objectId).ExecuteAsync();
                }
                catch (Exception e)
                {
                    if (Request.QueryString["reauth"] == "True")
                    {
                        //
                        // Send an OpenID Connect sign-in request to get a new set of tokens.
                        // If the user still has a valid session with Azure AD, they will not be prompted for their credentials.
                        // The OpenID Connect middleware will return to this controller after the sign-in response has been handled.
                        //
                        HttpContext.GetOwinContext()
                            .Authentication.Challenge(OpenIdConnectAuthenticationDefaults.AuthenticationType);
                    }
    
                    //
                    // The user needs to re-authorize.  Show them a message to that effect.
                    //
                    ViewBag.ErrorMessage = "AuthorizationRequired";
                    return View();
                }
    
                return View(user);
            }
