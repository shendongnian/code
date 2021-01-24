    var groups = await activeDirectoryClient.Groups.Where(g => g.DisplayName == groupName).Expand(g => g.Members)
                    .ExecuteAsync()
                    .Result.CurrentPage.ToList();
    var users = groups.SelectMany(g => 
        g.Members.CurrentPage.Select(m => m as User)).Where(u => u != null);
    var usersForGroup = new List<User>();
    if (users.Any())
    {
        groupUsers.AddRange(users);
    }
