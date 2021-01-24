    using (var db = new MyContext(connectionString))
    {
        var editedClientAccount = db.ClientAccounts.FirstOrDefault();
        editedClientAccount.OrgBalance = editedClientAccount.Balance;
        // Mimic editing in UI:
        editedClientAccount.Balance = DateTime.Now.Ticks;
        // Mimic concurrent update.
        Thread.Sleep(200);
        using (var db2 = new MyContext(connectionString))
        {
            db2.ClientAccounts.First().Balance = DateTime.Now.Ticks;
            db2.SaveChanges();
        }
        Thread.Sleep(200);
        
        // Mimic return from UI:
        var existingClient = db.ClientAccounts.Find(editedClientAccount.ID);
        db.Entry(existingClient).OriginalValues["Balance"] = editedClientAccount.OrgBalance;
        existingClient.Balance = editedClientAccount.Balance;
                
        db.SaveChanges(); // Throws the DbUpdateConcurrencyException
    }
