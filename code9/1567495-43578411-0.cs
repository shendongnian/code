    using (var dbConnection = new SqlConnection(connectionString))
    {
        dbConnection .Open();
        using (var dbCommand = new SqlCommand("select Count(*) from YourTable", dbConnection ))
        {
            return dbCommand.ExecuteScalar() == 0;
        }
    }
