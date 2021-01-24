    public static void SetStatus(Status statusObject, int retryCount)
    {
        if (statusObject == null)
            return;
        try
        {
            using (var dbConn = new SqliteConnection(dbURL))
            {
                IDbTransaction dbTransaction = null;
                try
                {
                    dbConn.Open();
                    dbTransaction = dbConn.BeginTransaction();
                    new SqliteCommand(some_query, dbConn).ExecuteNonQuery();
                    dbTransaction.Commit();
                }
                catch
                {
                    // transaction might be null if the connection couldn’t be opened
                    dbTransaction?.Rollback();
                    throw;
                }
            }
        }
        catch (Exception ex)
        {
            if (retryCount > 0)
                SetStatus(statusObject, --retryCount);
            else
                throw ex;
        }
    }
