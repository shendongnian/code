    var userList = new List<UserJson>();
    foreach (var id in resultList)
    {
        var users = db.Users.Find(id);
        string friend = users.Username;
        string profilePic = users.ProfilePic;
        
        userList.Add(new UserJson {Name = friend, Id = id, ProfilePic = profilePic });
    }
    string json = JsonConvert(userList);
