    public async Task<IHttpActionResult> UpdateUserProfile(UserProfile profile)
    {
        if (HttpContext.Current.Request.IsAuthenticated)
        {
            var ups = ApiServiceFactory.GetUserProfileService();
            var result = ups.UpdateUserProfile(profile);
            return true;
        }
        return false;
    }
