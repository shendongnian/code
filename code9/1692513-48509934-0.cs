    private async Task<List<User>> GetAdUsers() {
        var userPages = await client //Injected IActiveDirectoryClient from before
            .Users
            .ExecuteAsync()
            .ConfigureAwait(false);
        var users = userPages.CurrentPage.ToList();
        while(userPages.MorePagesAvailable) {
            userPages = await userPages.GetNextPageAsync().ConfigureAwait(false);
            users.AddRange(userPages.CurrentPage);
        }
        return users;
    }
	
