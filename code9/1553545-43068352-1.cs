    var currentUserId = "";// set current userId from Where are you holding (session,identity etc..)
    var result = db.Missions.OrderByDescending(x=>x.GivenDate).ToList();
    result = result.Where(x=> x.GivenUsers.Split(',').Contains(currentUserId));
        foreach (var item in result)
        {
            if (!string.IsNullOrEmpty(item.GivenUsers))
            {
                int[] Ids = Array.ConvertAll(item.GivenUsers.Split(','),
                                          delegate(string s) { return int.Parse(s); }) ;
        		string[] names = db.Users.Where(u => Ids.Contains(u.Id)).Select(u => u.Name+ " " + u.Surname).ToArray();
        		item.GivenUsers = string.Join(",",names);
             
            }               
        
        }
