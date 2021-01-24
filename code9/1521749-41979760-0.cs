    var group = await adClient.Groups.Where(g => g.ObjectId == groupObjectId).ExecuteSingleAsync();
    IGroupFetcher groupfetcher = (Group)group;
    var membersResult = await groupfetcher.Members.ExecuteAsync();
    var more = true;
    while (more)
    {
        foreach (var member in membersResult.CurrentPage) 
        {
        //... remember to handle that members can be other groups
        }
        if (!membersResult.MorePagesAvailable)
        {
            more = false;
        }
        else
        {
            // get next page in results
            membersResult = await membersResult.GetNextPageAsync();
        }
    }
