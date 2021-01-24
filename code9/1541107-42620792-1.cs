    static void Main(string[] args)
    {
        string authority = "https://login.microsoftonline.com/{0}";
        string graphResourceId = "https://graph.windows.net";
        string tenantId = "xxxx.onmicrosoft.com";
        string clientId = "";
        string secret = "";
        authority = String.Format(authority, tenantId);
        Uri servicePointUri = new Uri(graphResourceId);
        Uri serviceRoot = new Uri(servicePointUri, tenantId);
        AuthenticationContext authContext = new AuthenticationContext(authority);
        var accessToken = authContext.AcquireTokenAsync(graphResourceId, new ClientCredential(clientId, secret)).Result.AccessToken;
        ActiveDirectoryClient activeDirectoryClient = new ActiveDirectoryClient(serviceRoot, async () => await Task.FromResult(accessToken));
        var groupFetcher = (IGroupFetcher)activeDirectoryClient.Groups.ExecuteAsync().Result.CurrentPage.First(g => g.Mail == "group1@xxxx.onmicrosoft.com");
        var membersResoult = groupFetcher.Members.ExecuteAsync().Result;
        PrintMembers(membersResoult);
        while (membersResoult.MorePagesAvailable)
        {
            membersResoult = membersResoult.GetNextPageAsync().Result;
            PrintMembers(membersResoult);
        }
      
        Console.ReadLine();
    }
    static void PrintMembers(IPagedCollection<IDirectoryObject> pageCollection)
    {
        foreach (var member in pageCollection.CurrentPage)
        {
            var user = member as Microsoft.Azure.ActiveDirectory.GraphClient.User;
            if (user != null)
                Console.WriteLine(user.DisplayName);
            else
            {
                var groupMember = member as Microsoft.Azure.ActiveDirectory.GraphClient.Group;
                Console.WriteLine(groupMember.DisplayName);
            }
        }
    }
