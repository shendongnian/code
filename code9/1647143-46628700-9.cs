    using (TransactionScope tranScope = new TransactionScope())
    using (dbDataContext db = new dbDataContext())
    {
        try
        {
            var user = new User(){ID = 1, Name = "Nick"};
            db.Users.Add(user);
            db.SaveChanges();
            tranScope.Complete();
        }
        catch(Exception ex){}
    }
