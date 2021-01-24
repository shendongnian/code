    List<GroupPrincipal> groupList = new List<GroupPrincipal>
    {
        GroupPrincipal.FindByIdentity(ctx, "ADGROUP1"),
        GroupPrincipal.FindByIdentity(ctx, "ADGROUP1")
        // ...
    }
    foreach(var group in groupList) 
    {
        if(user.IsMemberOf(group)
        {
            // do something
        }
    }
