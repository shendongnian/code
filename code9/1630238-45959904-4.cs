    public void BulkInsertUsers(IEnumerable<tblUsers> users)
    {
        using (var ctx = new tblUsers())
        {
            // users is detached from database, so we need to add it
            ctx.Attach(users); 
            // Specify that these are modified entities (may not be necessary for BulkInsert)
            // I don't know what properties users contain, so used Name
            ctx.Entry(tblUsers).Property(a => a.Name).IsModified = true;
            ctx.BulkInsert(users);
            ctx.SaveChanges();
        }
    }
