    using (var txn = new TransactionScope(
                    TransactionScopeOption.RequiresNew, 
                    new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted })
    {
        return base.Database.ExecuteSqlCommand("EXEC mystoredprocedure");
    }
