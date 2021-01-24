    using (SqlConnection sourceConnection = new SqlConnection())
    using (var destinationConnection = new SqlConnection())
    {
       sourceConnection.Open(); 
       destinationConnection.Open();
    }
