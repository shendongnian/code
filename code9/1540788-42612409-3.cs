    using (var db = new MyContext())
    {
        var user = db.Users.Include(u => u.AccessToken)
                     .Single(u => u.Id == 1);
    }
