    private static void Select(SqlConnection c, string sql)
    {
        using (var cmd = c.CreateCommand())
        {
            cmd.CommandText = sql;
            using (var reader = cmd.ExecuteReader())
            {
                do
                {
                    if ( reader.Read() )
                        Console.WriteLine(reader.GetInt32(0));
                }
                while ( reader.NextResult() );
            }
        }
    }
