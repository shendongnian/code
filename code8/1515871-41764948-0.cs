    using (var db = new myEntities())
    {
        // this shows ReadCommitted
        Console.WriteLine($"Isolation level outside TransactionScope = {db.Database.SqlQuery(typeof(string), selectIsolationLevel).Cast<string>().First()}");
    }
    using (var scope =
        new TransactionScope(TransactionScopeOption.RequiresNew,
        new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
    {
        // this show ReadUncommitted
        Console.WriteLine($"Isolation level inside TransactionScope = {db.Database.SqlQuery(typeof(string), selectIsolationLevel).Cast<string>().First()}");
        using (myEntities db = new myEntities ())
        {
            var data = from _Contact in db.Contact where _Contact.MemberId == 13 select _Contact; // large results but with nolock
            for (var item I data)
                  item.Flag = 0;
            db.SaveChanges(); // Try avoid db lock
        }
        // this should be added to actually Commit the transaction. Otherwise it will be rolled back
        scope.Complete();
    }
