    IEnumerable<User> listUsers = ..// From DB 
    List<User> salistUsers = new List<User>();
    if (listUsers != null && !listUser.Any())
    {                          
         var filteredUsers = listStations.Where(x => x.GroupID == item).ToList();   
         salistUsers.Add(filteredUsers);                                            
    }
