    using (var transaction = connection.BeginTransaction())
    {
        try
        {
            CreateTables(connection);
            InsertPlatforms(connection, platformList);
        }
        catch (Exception e)
        {
            transaction.Rollback();
            throw;
        }
        transaction.Commit();
    }
