        using (SqlConnection conn = new SqlConnection(sqlConnection))
        {
            conn.Open();
            var cmd = conn.CreateCommand();
            using (cancellationToken.Register(() => cmd.Cancel()))
            {
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
        }
