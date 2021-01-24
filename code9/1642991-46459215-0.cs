    //this is how you can get the index of the user in an ordered list. "_newUserName" is being passed in, either as a User object or string (your call)
    var index = User.Select((user, index) => new {user,index}).OrderBy(a=>a.user.UserName).Where(a=>a.user.UserName == "_newUserName").Select(a=>a.index);
    //then determine the page new user sits on
    var page = (index / pageSize ) + 1;
    return UserManager.Users
            .OrderBy(u => u.UserName)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();
