    public async Task<AADUser> GetUserByPrincipalName(string userName)
        {
            var user = await GetUserByUserName(activeDirectoryClient, userName);
            return new AADUser()
            {
                displayName = user.DisplayName
            };
          
        }
