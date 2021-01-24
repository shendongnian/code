    using (var sourceConnection = new SqlConnection())
    {
        sourceConnection.Open(); 
        using (var destinationConnection = new SqlConnection())
        {
            destinationConnection.Open();
            // ...
            using (var myReader = srcConnection.ExecuteReader(...))
            {
                // ...
            }
        }
    }
