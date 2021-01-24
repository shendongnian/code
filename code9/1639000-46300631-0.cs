    public async Task Do()
    {
        var graphClient = new GraphServiceClient(_authProvider);
        var groups = await graphClient.Groups.Request().GetAsync();
        do
        {
            foreach (var group in groups)
            {
                Console.WriteLine($"{group.Id}, {group.DisplayName}");
                Console.WriteLine("------");
                var users = await graphClient.Groups[group.Id].Members.Request().GetAsync();
                do
                {
                    foreach (var user in users)
                    {
                        Console.WriteLine($"{user.Id}");
                    }
                }
                while (users.NextPageRequest != null && (users = await users.NextPageRequest.GetAsync()).Count > 0);
                Console.WriteLine("------");
                Console.WriteLine();
            }
        }
        while (groups.NextPageRequest != null && (groups = await groups.NextPageRequest.GetAsync()).Count > 0);
    }
