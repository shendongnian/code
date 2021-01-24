    List<Dictionary<string, object>> friends = new List<Dictionary<string, Object>>();
    
    foreach (var id in resultList)
    {
        var user = db.Users.Find(id);
        string friend = user.Username;
        
        Dictionary<string, object> dictFriend = new Dictionary<string, Object>();
        dictFriend.Add("id", id);
        dictFriend.Add("name" , friend);
        friends.Add(dictFriend);
    }
    
    string json = JsonConvert.SerializeObject(friends);
