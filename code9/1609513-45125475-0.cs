    using(var db = new MyDbContext())
    {
        db.Configuration.ProxyCreationEnabled = false;
        var data = db.Users.ToList(); // suppose you have 10 milion users
    }
