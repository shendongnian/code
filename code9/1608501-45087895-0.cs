    using (var db = new Entities.DB.DConn())
    {
        //...
        var accountIds = accounts.Select(x => x.GId); // variable required by EF6 Contains translation
        var existingAccountIds = new HashSet<GId_Type>(
            db.Accouns.Where(x => accountIds.Contains(x.GId).Select(x => x.GId));
        foreach (Account account in accounts)
        {
            var dlAccount = new Entities.DB.Account();
            dlAccount.GId = account.GId;
            dlAccount.AccountName = account.NameAtFI;
            dlAccount.AccountNumber = account.AcctNumber;
            dlAccount.AcctType = account.AcctType;
            dlAccount.AsOfDate = account.DateCreated;
            dlAccount.IsDeleted = false;
            dlAccount.DateModified = DateTime.UtcNow.ToUniversalTime();    
            if (existingAccountIds.Contains(dlAccount.GId))
                db.Entry(dlAccount).State = EntityState.Modified; // update
            else
                db.Accounts.Add(dlAccount); // insert
        }
        db.SaveChanges();
    }
