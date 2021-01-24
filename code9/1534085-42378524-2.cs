    using (var connection = new SqlConnection(connectionString))
    {
        string sql = "SELECT enabled FROM dbo.products WITH(nolock) WHERE name = @name";
        using (var command = new SqlCommand(sql, connection)) {
            command.Parameters.AddWithValue("name", name);
            command.CommandTimeout = 100;
            connection.Open();
            object enabled = command.ExecuteScalar();
            if (enabled == null) {
                ... // Product does not exist.
            } else if ((int)enabled == 0) {
                ... // Product is disabled.
            } else {
                ... // Product is enabled.
            }
        }
    }
