     using (var ctx = new MyContext()) 
                { 
                    using (var dbContextTransaction = ctx.Database.BeginTransaction()) 
                    { 
                        try 
                        { 
                            //1st operations here
                            ctx.GroupsDetails.RemoveRange(ctx.GroupsDetails);
                            ctx.LinkTable.RemoveRange(ctx.LinkTable);
                            ctx.SaveChanges(); 
                            //2nd operations here
                            ctx.Users.AddRange(usersSave);
                            ctx.UserPreferences.AddRange(userPrefsSave);
                            ctx.SaveChanges();
     
                            dbContextTransaction.Commit(); 
                        } 
                        catch (Exception) 
                        { 
                            dbContextTransaction.Rollback(); 
                        } 
                    } 
                } 
