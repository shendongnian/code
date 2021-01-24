    var result = userList.GroupBy(user=>user.GroupID)
                         .Select(group=> new 
                                  {
                                    GroupID = group.Key,
                                    UserIDs = String.Join(",", group.Select(x=>x.UserID)),
                                    UserNames = String.Join(",", group.Select(x=>x.UserName))
                                  }); 
