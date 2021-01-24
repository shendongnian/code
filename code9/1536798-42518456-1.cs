                AuthenticationResult result;
                try
                {
                     result = await authContext.AcquireTokenSilentAsync(resourceId, clientId);
                }
                catch (AdalException ex)
                {
                    if (ex.ErrorCode == "failed_to_acquire_token_silently")
                    {
                        // There are no tokens in the cache. 
                        result = await authContext.AcquireTokenAsync(resourceId, clientId, redirectUri, new PlatformParameters(PromptBehavior.Always));
                    }
                    else
                    {
                        // An unexpected error occurred.
                        string message = ex.Message;
                        if (ex.InnerException != null)
                        {
                            message += "Inner Exception : " + ex.InnerException.Message;
                        }
                        MessageBox.Show(message);
                    }
