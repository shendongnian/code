            if (_OneDriveCacheBlob == null)
            {
                bool needtosaveblob = true;
                _OneDriveCacheBlob = null;
                CredentialCache cc = new CredentialCache();
                _OneDriveCacheBlob = GetUser(CurrentUserName).OneDriveAuthProviderBlob;
                if (_OneDriveCacheBlob != null)
                {
                    cc.InitializeCacheFromBlob(_OneDriveCacheBlob);
                    needtosaveblob = false;
                }
                MsaAuthenticationProvider msaAuthProvider = new MsaAuthenticationProvider(OneDriveClass.clientId, OneDriveClass.returnUrl, scopes, cc);
                int timeout = 15;
                _ = Task.Run(() => WaitForODConnection(msaAuthProvider));                
                while (!WaitForODConnectionExecuted)
                {
                    if (timeout <= 0)
                        break;
                    await Task.Delay(TimeSpan.FromSeconds(1));
                    timeout -= 1;
                }
                WaitForODConnectionExecuted = false;
                if (timeout <= 0)
                {
                    // Request for reconnection to OneDrive because of invalid Blob                    
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
                    {
                        //This method requests a new login by a simple msaAuthProvider.AuthenticateUserAsync() call from a new instance of MsaAuthenticationProvider and a new instance of CredentialCache.
                        //ChangeOneDriveAccount(); 
                    });
                }
                else
                {
                    _OneDriveClient = new OneDriveClient(OneDriveClass.basUrl, msaAuthProvider);
                }
                string accessToken = msaAuthProvider.CurrentAccountSession.AccessToken;
                JObject json = await GetUserInfos(msaAuthProvider.CurrentAccountSession.AccessToken);
                if (json != null)
                {
                    // If you need
                    oneDriveUserName = json["name"].ToString();
                    oneDriveEmail = json["emails"]["account"].ToString();
                }
                else
                {
                    //Unable to get OneDrive user informations;                    
                }
                if (needtosaveblob)
                {
                    _OneDriveCacheBlob = cc.GetCacheBlob();
                    //You can save _OneDriveCacheBlob to reuse it later;
                }
            }
