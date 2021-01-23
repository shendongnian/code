     using (var ctx = new MyContext()) 
                { 
                    using (var dbContextTransaction = ctx.Database.BeginTransaction()) 
                    { 
                        try 
                        { 
                            //your operations here
     
                            ctx.SaveChanges(); 
     
                            dbContextTransaction.Commit(); 
                        } 
                        catch (Exception) 
                        { 
                            dbContextTransaction.Rollback(); 
                        } 
                    } 
                } 
