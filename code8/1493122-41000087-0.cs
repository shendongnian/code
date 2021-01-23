            using (var context = new dbContext()) 
            { 
                using (var dbContextTransaction = context.Database.BeginTransaction()) 
                { 
                    try 
                    { 
                        dbContext.MyTable.Add(obj1);
                        
                        //obj1 should be on the context now 
                        dbContext.MyTable.Where(.....)
                        context.SaveChanges(); 
 
                        dbContextTransaction.Commit(); 
                    } 
                    catch (Exception) 
                    { 
                        dbContextTransaction.Rollback(); 
                    } 
                } 
            } 
