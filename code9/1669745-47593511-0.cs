            public void UpdateUserMembership(int userId, IList<int> groupIds)
            {
                var user = dbContext.Users
                    .Include(u => u.Groups)
                    .First(u => u.Id == userId);
                var currentGroups = user.Groups;
                foreach (var currentGroup in currentGroups)
                {
                    dbContext.UserGroups.Remove(currentGroup);
                }
                dbContext.SaveChanges();
                foreach (var groupId in groupIds)
                {
                    var userGroup = new UserGroup { UserId = userId, GroupId = groupId}
                    dbContext.UserGroups.Add(userGroup);
                }
                dbContext.SaveChanges();
            }
