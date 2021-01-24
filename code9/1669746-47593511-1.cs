            public void UpdateUserMembership(int userId, IList<int> groupIds)
            {
                var user = dbContext.Users
                    .Include(u => u.Groups)
                    .First(u => u.Id == userId);
                var currentGroups = user.Groups;
                var groupsWhichWillDeleted = currentGroups.Where(x => !groupIds.Contains(x.GroupId)).ToList();
                var groupsWhichWillInserted = groupIds.Where(x => !currentGroups.Any(c => c.GroupId == x)).ToList();
                foreach (var deletedGroup in groupsWhichWillDeleted)
                {
                    dbContext.UserGroups.Remove(deletedGroup);
                }
                foreach (var insertedGroupId in groupsWhichWillInserted)
                {
                    var userGroup = new UserGroup { UserId = userId, GroupId = insertedGroupId };
                    dbContext.UserGroups.Add(userGroup);
                }
                dbContext.SaveChanges();
            }
