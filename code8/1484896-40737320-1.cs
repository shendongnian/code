    using (var context = new YourContext()) 
                { 
                    using (var dbContextTransaction = context.Database.BeginTransaction()) 
                    { 
                        try 
                        { 
                            // your operations here
    
                            context.SaveChanges(); //this called only once
                            dbContextTransaction.Commit(); 
                        } 
                        catch (Exception) 
                        { 
                            dbContextTransaction.Rollback(); 
                        } 
                    } 
                } 
