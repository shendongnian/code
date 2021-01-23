        /// <summary>
        /// This method requests Authentcation from a user using Oauth2.  
        /// Credentials are stored in System.Environment.SpecialFolder.Personal
        /// Documentation https://developers.google.com/accounts/docs/OAuth2
        /// </summary>
        /// <param name="clientSecretJson">Path to the client secret json file from Google Developers console.</param>
        /// <param name="userName">Identifying string for the user who is being authentcated.</param>
        /// <returns>DriveService used to make requests against the Drive API</returns>
        public static DriveService AuthenticateOauth(string clientSecretJson, string userName)
        {
            try
            {
                if (string.IsNullOrEmpty(userName))
                    throw new Exception("userName is required.");
                if (!File.Exists(clientSecretJson))
                    throw new Exception("clientSecretJson file does not exist.");
                // These are the scopes of permissions you need. It is best to request only what you need and not all of them
                string[] scopes = new string[] {DriveService.Scope.DriveReadonly};           // Modify your Google Apps Script scripts' behavior
                UserCredential credential;
                using (var stream = new FileStream(clientSecretJson, FileMode.Open, FileAccess.Read))
                {
                    string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    credPath = Path.Combine(credPath, ".credentials/apiName");
                    // Requesting Authentication or loading previously stored authentication for userName
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets,
                                                                             scopes,
                                                                             userName,
                                                                             CancellationToken.None,
                                                                             new FileDataStore(credPath, true)).Result;
                }
                // Create Drive API service.
                return new DriveService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = "Drive Authentication Sample",
                    });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Create Oauth2 DriveService failed" + ex.Message);
                throw new Exception("CreateOauth2DriveFailed", ex);
            }
        }
