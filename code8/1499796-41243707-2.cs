    public async Task<AuthorizationResult> UpdateUserProfile(UserProfile profile)
    {
        try
        {
            var ups = ApiServiceFactory.GetUserProfileService();
            var result = ups.UpdateUserProfile(profile);
            return new AuthorizationResult();
        }
        catch (Exception ex)
        {
            // Just an example of how to get a message.
            // Depending on your implementation, you might be returning a 
            // message from UpdateUserProfile(profile).
            return new AuthorizationResult(ex.Message);
        }
    }
