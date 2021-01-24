        using (SqlConnection conn = new SqlConnection(sqlConnection))
        {
            conn.Open();
            var cmd = conn.CreateCommand();
            // Below is a key line:
            cancellationToken.Register(() => cmd.Cancel());
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
