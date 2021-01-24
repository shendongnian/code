    using (var db = new Entities.DB.DConn())
    {
        //...
        foreach (Account account in accounts)
        {
            Entities.DB.Account exisitngAcct = db.Accounts.FirstOrDefault(x => x.GId == dlG.Id).FirstOrDefault(); //x.GId is NOT ad primary key
    
            //NB. Since we're already pulling up the record with EF, there is *probably* no measurable advantage in not just using EF tracking at this point (unless this is a HUUUGE list of objects)
            //    in which case we should use the .AsNoTracking() modifier when we load the records (and they should be loaded in batches/all at once, to reduce DB hits)
            
            Entities.DB.Account dlAccount = new Entities.DB.Account();
            if(exisitngAcct == null)
            {
                db.Entry(dlAccount).State = EntityState.Added;
            }
            else
            {
                dlAccount.Id = exisitngAcct.Id; //We have to set the PK, so that EF knows which object to update
                db.Entry(dlAccount).State = EntityState.Modified;
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
