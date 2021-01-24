     using (var dbContext = new DbContextTest("DatabaseConnectionString"))
      {
        var users = dbContext.Users.Select(u => u).Where(x => x.UserId > 0);
        var query = dbContext.Users.Where(x => users.Contains(x));
        Console.WriteLine(query.ToList());
      }
    
      using (var dbContext = new DbContextTest("DatabaseConnectionString"))
      {
        var ids = dbContext.Users.Select(u => u.UserId).Where(x => x > 0);
        var query = dbContext.Users.Where(x => ids.Contains(x.UserId));
        Console.WriteLine(query.ToList());
      }
