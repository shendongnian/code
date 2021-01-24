    try
    {
        sqlConnection.Open();
        table = cmd.ExecuteDataTable();
    }
    finally
    {
        sqlConnection.Dispose();
    }
