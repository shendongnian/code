    using (var conn = new SqlConnection(cnnString))
    using (var cmd = conn.CreateCommand())
    {
        conn.Open();
        cmd.CommandText = "SearchCustomer";
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        // Use below line if you want to pass any parameter values to SP.
        cmd.Parameters.AddWithValue("@id", CustomerId);
        using (var reader = cmd.ExecuteReader())
        {
            if (reader.Read())
            {
             Console.WriteLine(reader.GetString(reader.GetOrdinal("columnName"));
            }
        }
    }
