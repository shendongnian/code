    var connection = GetDbConnectionByUser(string user);
    using (var ctx = new ApplicationDbContext(connection))
    {
        ....
    }
