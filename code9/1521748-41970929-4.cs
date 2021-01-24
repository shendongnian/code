    var groups = await activeDirectoryClient.Groups
        .Where(g => g.DisplayName == groupName).Expand(g => g.Members)
        .ExecuteAsync();
    var usersForGroup = new List<User>();
    foreach(IGroup thisGroup in groups)
    {
        do
        {
            var thisGroupUsers = 
                thisGroup.Members.CurrentPage.Select(m => m as User)).Where(u => u != null);
            allUsers.AddRange(thisGroupUsers);
            // get next page asynchronously
            await thisGroup.Members.GetNextPageAsync();
        } while(thisGroup.Members.MorePagesAvailable)
        
    }
