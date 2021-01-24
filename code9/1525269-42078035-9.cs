    var users = new List<User>()
    {
        new User { Name = "Foo", SubUser = new Sub_User { Name = "Bar" } },
        new User { Name = "FooBar" }
    };
    
    users.ForEach(u => context.Users.Add(u));
    
    context.SaveChanges();
