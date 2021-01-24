      private static KeyVaultClient KeyVaultClient
            {
                get
                {
                    if (lastAuthenticationResult != null && DateTime.UtcNow.AddSeconds(5) < lastAuthenticationResult.ExpiresOn)
                    {
                        if (m_cachedKeyVaultClient != null)
                        {
                            return m_cachedKeyVaultClient;
                        }
                        else
                        {
                            return new KeyVaultClient(getCachedToken);
                        }
                    }
    
                    if (m_keyVaultClient == null)
                        m_keyVaultClient = new KeyVaultClient(GetAccessTokenAsync);
    
                    return m_keyVaultClient;
                }
            }
  
     private static async Task<string> getCachedToken(string authority, string resource, string scope)
            {
                return lastAuthenticationResult.AccessToken;
            }
