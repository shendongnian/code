     public static async Task<GraphServiceClient> GetAuthenticatedClientAsync()
        {
            GraphServiceClient graphClient = new GraphServiceClient(
                new DelegateAuthenticationProvider(
                    async (requestMessage) =>
                    {
                        string appID = ConfigurationManager.AppSettings["ida:AppId"];
 
                        PublicClientApplication PublicClientApp = new PublicClientApplication(appID);
                        string[] _scopes = new string[] { "Calendars.read", "Calendars.readwrite", "Mail.read", "User.read" };
 
                        AuthenticationResult authResult = null;
 
                        string keyName = @"Software\xxx\Security";
                        string valueName = "Status";
                        string token = "";
 
                        RegistryKey regKey = Registry.CurrentUser.OpenSubKey(keyName, false);
                        if (regKey != null)
                        {
                            token = (string)regKey.GetValue(valueName);
                        }
 
                        if (regKey == null || string.IsNullOrEmpty(token))
                        {
                            authResult = await PublicClientApp.AcquireTokenAsync(_scopes); //Opens Microsoft Login Screen
                            //code if key Not Exist
                            RegistryKey key;
                            key = Registry.CurrentUser.CreateSubKey(@"Software\xxx\Security");
                            key.OpenSubKey(@"Software\xxx\Security", true);
                            key.SetValue("Status", authResult.AccessToken);
                            key.SetValue("Expire", authResult.ExpiresOn.ToString());
                            key.Close();
                            // Append the access token to the request.
                            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", token);
                        }
                        else
                        {
                            //code if key Exists
                            RegistryKey reg = Registry.CurrentUser.OpenSubKey(@"Software\xxx\Login", true);
                            // set value of "abc" to "efd"
                            token = (string)regKey.GetValue(valueName);
                            // Append the access token to the request.
                            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", token);
                        }
                    }));
            try
            {      
                Microsoft.Graph.User me = await graphClient.Me.Request().GetAsync();
 
            }
            catch(Exception e)
            {
                if (e.ToString().Contains("Access token validation failure") || e.ToString().Contains("Access token has expired"))
                {
                    string keyName = @"Software\xxx\Security";
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName, true))
                    {
                        if (key != null)
                        {
                            key.DeleteValue("Status");
                            key.DeleteValue("Expire");
                        }
                        else
                        {
                            MessageBox.Show("Error! Something went wrong. Please contact your administrator.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    await GetAuthenticatedClientAsync();
                }
            }
           
            return graphClient;
        }
