    public void RegisterUser(string userName)
    {
        ravenSession.Advanced.WaitForIndexesAfterSaveChanges(timeout: TimeSpan.FromSeconds(30));
        var user = new User {...};
        ravenSession.Store(user);
        ravenSession.SaveChanges(); // This won't return until the User is stored *AND* the indexes are updated.
    };
