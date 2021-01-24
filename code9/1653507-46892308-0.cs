    var userlistdict = userlist.ToDictionary(x => x.name, x =>  x );
    User user;
    if (userlistdict.TryGetValue("b",  out user))
    {
        Console.WriteLine(user.age);
    }
