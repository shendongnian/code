    protected override bool AuthorizeCore(HttpContextBase httpContext) {
        if(string.IsNullOrWhiteSpace(Actions))
        {
            return true;
        }
        UserCache userCache = HELPERS.GetCurrentUserCache();
        return userCache.UserActionsDictionary[userCache.CurrentTenantID.ToString()].Intersect(Actions.Split(',').ToList()).Any();
    }
