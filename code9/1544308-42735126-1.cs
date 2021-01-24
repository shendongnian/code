    using(Entities dbContext = new Entities())
    {
            //Get data from database
    
            //check data from database
    
            //if my data is the expected: return true;
               
    using (DbContextTransaction myTransaction = dbContext.Database.BeginTransaction())
        {
             //if not is expected:
                try 
                 {
                   //update data;
                   //dbContext.Savechages();
                   //myTransaction.Commit();
                   //return true;
                 }
               catch(Exception ex)
               {
                transaction.Rollback();
                ......
                return false;
            }
        }
    }
