    SqlConnection sourceConnection = new SqlConnection();
    try
    {
       sourceConnection.Open(); 
       var destinationConnection = new SqlConnection();
       destinationConnection.Open();
    }
    finally
    {
        if (sourceConnection != null)
        {
            sourceConnection.Dispose();
        }
    }
