    using (var connection = new SqlConnection(_connectionString))
    {
        using(var command = new SqlCommand("sp_ImportData", connection))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ImportData", SqlDbType.Structured).Value = table;
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
