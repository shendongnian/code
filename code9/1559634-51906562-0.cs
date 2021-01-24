    public static bool DBExists(string connectionStr, string dbname)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionStr))
            {
                string sql = $"SELECT DATNAME FROM pg_catalog.pg_database WHERE DATNAME = '{dbname}'";
                using (NpgsqlCommand command = new NpgsqlCommand
                    (sql, conn))
                {
                    try
                    {
                        conn.Open();
                        var i = command.ExecuteScalar();
                        conn.Close();
                        if (i != null && i.ToString().Equals(dbname)) //always 'true' (if it exists) or 'null' (if it doesn't)
                            return true;
                        else return false;
                    }
                    catch (Exception e) {
                        Console.WriteLine(e.ToString());
                        return false;
                    }
                }
            }
        }
