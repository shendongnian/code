    using (var db = new Entities.DB.DConn())
    {
        //...
        foreach (Account account in accounts)
        {
            Entities.DB.Account dlAccount = null;
            Entities.DB.Account exisitngAcct = db.Accounts.Where(x => x.GId == dlG.Id).FirstOrDefault(); //x.GId is NOT ad primary key
            if (exisitngAcct != null)
            {
                //If there is an EXISTING account, it will already be tracked by EF so no need to attach it.
                dlAccount = exisitngAcct;                
            }
            else
            {
                //No account exists, so we need to create one, and ADD it to our EF context as a new Entity 
                dlAccount = new Entities.DB.Account();
                db.Accounts.Add(dlAccount);
            }
    
            dlAccount.GId = dlG.Id;
            dlAccount.AccountName = account.NameAtFI;
            dlAccount.AccountNumber = account.AcctNumber;
            dlAccount.AcctType = account.AcctType;
            dlAccount.AsOfDate = account.DateCreated;
            dlAccount.IsDeleted = false;
            dlAccount.DateModified = DateTime.UtcNow.ToUniversalTime();
        
            db.SaveChanges();
        }
    }
