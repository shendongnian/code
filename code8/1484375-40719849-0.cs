    public static void Method1()
    {
        using (TransactionScope scope = new TransactionScope())
        {
            bool success = true; // will be set to false in an omitted catch
            bool isSomethingHappened
            using (var connection = new SqlConnection(ConnectionString1))
            {
               isSomethingHappened = // Execute query 1
            }
           if(somethingHappened)
               Method2();
            if(success)
                scope.Complete();
        }
    }
