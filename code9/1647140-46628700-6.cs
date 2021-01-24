    using (dbDataContext db = new dbDataContext())
    using (var dbContextTransaction = db.Database.BeginTransaction()) 
    {
        try
        { 
            var user = new User(){ID = 1, Name = "Nick"};
            db.Users.Add(user);
            db.SaveChanges();
            dbContextTransaction.Commit(); 
        } 
        catch (Exception) 
        { 
            dbContextTransaction.Rollback(); 
        }
    } 
