    List<GroupPrincipal> groupList = new List<GroupPrincipal>
    {
        GroupPrincipal.FindByIdentity(ctx, "ADGROUP1"),
        GroupPrincipal.FindByIdentity(ctx, "ADGROUP1")
        // ...
    }
    if(groupList.All(g => user.IsMemberOf(g)) 
    { 
        // do something 
    }
