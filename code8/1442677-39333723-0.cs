    // Iterates over all enabled users.
    var users = await graphClient.Users.Where(u => u.AccountEnabled == true).ExecuteAsync();
    do
    {
        foreach (var user in users.CurrentPage)
        {
            Console.WriteLine("Enabled user: {0}", user.UserPrincipalName);
        }
        users = await users.GetNextPageAsync();
    } while (users != null);
