    public async Task<List<Generic.UserAAD>> GetUsersAAD()
    {
        ActiveDirectoryClient activeDirectoryClient = AuthenticationHelper.GetActiveDirectoryClientAsApplication();
        Task<IPagedCollection<IUser>> usersTask = activeDirectoryClient.Users.ExecuteAsync();
        IPagedCollection<IUser> usersA = await usersTask;
        List<IUser> queryUsers = new List<IUser>();
        List<Generic.UserAAD> listUsers = new List<Generic.UserAAD>();
        do
        {
            List<IUser> queryUsersList = usersA.CurrentPage.ToList();
            queryUsers.AddRange(queryUsersList);
            usersA = usersA.MorePagesAvailable ? await usersA.GetNextPageAsync() : null;
        } while (usersA != null);
        if (queryUsers.Count > 0)
        {
            listUsers = queryUsers.Select(u => new Generic.UserAAD { DName = u.DisplayName, UName= u.UserPrincipalName }).ToList();
        }
        return listUsers;
    }
