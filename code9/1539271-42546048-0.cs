    using (var conn = new System.Data.SqlClient.SqlConnection(connectionString)) {
        conn.Open();
        using (var cmd = conn.CreateCommand()) {
            cmd.CommandText = "SELECT 'hello world'";
            using (var reader = cmd.ExecuteReader()) {
                while (reader.Read()) {
                    ...
                }
            }
        }
    }
