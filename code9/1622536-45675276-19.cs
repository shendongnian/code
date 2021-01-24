    public void ExecuteReaderExample(string dbName, string sql)
    {
        Execute("dbName",
        connection =>
        {
            using (var cmd = new SqlCommand(sql, connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // do stuff with data form the database
                    }
                }
            }
        });
    }
