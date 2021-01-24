    using (SqlConnection connection1 = new SqlConnection(connectString1))
    {
        connection1.Open();
        using (TransactionScope scope = new TransactionScope())
        {
            ... // some commands
            // if you need to rollback and execute other command
            if(blabla)
            {
                scope.Dispose(); // without this further command is also rolled back
                ... // command
            }
            else
                scope.Complete(); // everything is fine, confirm transaction
        }
    }
