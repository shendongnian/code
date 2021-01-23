    using(var conn = new AppContext())
    {
    
        var allUsers = conn.Users.WhereContainsAnyWord(user => user.FirstName, "Some Full Name Goes Here").ToList();
    
    }
