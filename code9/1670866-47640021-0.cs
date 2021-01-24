    using (var context = new SekhavatDBEntities()) 
    { 
    	using (var dbContextTransaction = context.Database.BeginTransaction()) 
    	{ 
    		var account = context.Accounts.First(acc => acc.Id == new Guid("79B7AAC6-AD2D-4824-907E-16ADB4C41EE1"));            
    		account.Balance = 50;
    		context.SaveChanges();
    
    		dbContextTransaction.Rollback(); 
    	} 
    } 
