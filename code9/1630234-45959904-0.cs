    public void BulkInsertUsers(IEnumerable<tblUsers> users)
    {
        using (var ctx = new tblUsers())
        {
            // users is detached from database, so we need to add it
            ctx.Attach(users); 
            ctx.BulkInsert(users);
            ctx.SaveChanges();
        }
    }
