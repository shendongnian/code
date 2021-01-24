        List<(int ID, string FirstName, string LastName)> queryResults = new List<(int ID, string FirstName, string LastName)>();
        
        using (IDbConnection conn = new SqlConnection(myConnectionString))
        {
            conn.Open();
            using (IDbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT ID, FirstName, LastName FROM Users";
                using (IDataReader r = cmd.ExecuteReader())
                {
                    while (r.NextResult())
                    {
                        int id = r.GetInt32(0);
                        string firstname = r.GetString(1);
                        string lastname = r.GetString(2);
                        queryResults.Add((id, firstname, lastname));
                    }
                }
            }
        }
