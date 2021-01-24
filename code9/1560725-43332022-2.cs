    public void testInsertRow()
    {
        using(TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, 
                                                            new TransactionOptions(IsolationLevel = IsolationLevel.Snapshot))
        {
            SqlConnection c = new SqlConnection("connection.string.here");
            insertRow(c);
            // do something here to evaluate what happened, e.g. query the DB
            //do not call scope.Complete() so we get a rollback.
        }   
    }
