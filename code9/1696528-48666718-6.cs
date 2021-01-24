    var result = userList.GroupBy(user=>user.GroupID)
                         .Select(group=> new 
                                  {
                                    GroupID = group.Key,
                                    UserIDs = group.Select(x=>x.UserID).ToList(),
                                    UserNames = group.Select(x=>x.UserName).ToList()
                                  }); 
