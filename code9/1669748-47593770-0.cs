    public void UpdateUserMembership(int userId, IList<int> groupIds)
    {
        var user = dbContext.Users
                      .Include(u => u.Groups)
                      .First(u => u.Id == userId);
    
        var diffIdList = groupIds.Except(user.Groups.SelectMany(x => x.GroupId)).ToList();
    
        foreach (var groupId in diffIdList)
        {
            var userGroup = new UserGroup { UserId = userId, GroupId = groupId };
            dbContext.UserGroups.Add(userGroup);
        }
    
        dbContext.SaveChanges();
    }
