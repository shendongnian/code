    using (var transaction = dbContext.Database.BeginTransaction(System.Data.IsolationLevel.RepeatableRead))
        try {
            // Read status, process payment here
            
            dbContext.SaveChanges();
            transaction.Commit()
        } 
        catch (Exception e) {
            transaction.Rollback();
            throw e;
        }
    }
