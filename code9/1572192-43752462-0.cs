                AuthenticationResult result = null;
                try
                {
                    string userObjectID = (User.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier"))?.Value;
                    AuthenticationContext authContext = new AuthenticationContext(Startup.Authority, new NaiveSessionCache(userObjectID, HttpContext.Session));
                    ClientCredential credential = new ClientCredential(Startup.ClientId, Startup.ClientSecret);
                    result = await authContext.AcquireTokenSilentAsync("https://graph.windows.net", credential, new UserIdentifier(userObjectID, UserIdentifierType.UniqueId));
                    var userData = new
                    {
                        accountEnabled = true,
                        displayName = "nan yu",
                        mailNickname = "nanyu",
                        passwordProfile = new
                        {
                            password = "xxxxxx",
                            forceChangePasswordNextLogin = false
                        },
                        userPrincipalName = "nanyuTest54@testbasic1.onmicrosoft.com"
                    };
                    // Forms encode todo item, to POST to the Azure AD graph api.
                    HttpContent content = new StringContent(JsonConvert.SerializeObject(userData), System.Text.Encoding.UTF8, "application/json");
    
                    //
                    // Add the azure ad user.
                    //
                    HttpClient client = new HttpClient();
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://graph.windows.net/myorganization/users?api-version=1.6");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);
                    request.Content = content;
                    HttpResponseMessage response = await client.SendAsync(request);
    
                    //
                    // Return user in the view.
                    //
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        //
                        // If the call failed with access denied, then drop the current access token from the cache, 
                        //     and show the user an error indicating they might need to sign-in again.
                        //
                        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                        {
                          
                        }
                    }
    
                }
                catch (Exception ee)
                {
                    //
                    // The user needs to re-authorize.  Show them a message to that effect.
                    //
              
                }
