    if (listUsers != null && !listUser.Any())
    {                          
         var filteredUsers = listUsers.Where(x => x.GroupID == item).ToList();
         salistUsers.AddRange(filteredUsers);                                            
    }
