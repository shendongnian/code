    string connectionString = "Your connection string here";
    
    protected static int ExecuteQuery(string query)
            {
                using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
                {
                    con.Open();
                    using (NpgsqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.Text;
                        int result = cmd.ExecuteNonQuery();
                        return result;
                    }
                }
            }
