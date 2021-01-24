        public List<Dictionary<String, object>> P2a(string sql, MySqlParameter[] parameters)
        {
            List<Dictionary<String, object>> result = new List<Dictionary<String, object>>();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                using (MySqlConnection mysqlconnection = new MySqlConnection(xxx))
                {
                    cmd.Connection = mysqlconnection;
                    cmd.CommandText = sql;
                    if (parameters != null)
                    {
                        foreach (MySqlParameter p in parameters)
                        {
                            cmd.Parameters.Add(p);
                        }
                    }
                    try
                    {
                        cmd.Connection.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Dictionary<string, object> dict = new Dictionary<string, object>();
                                for (int count = 0; (count <= (reader.FieldCount - 1)); count++)
                                {
                                    dict.Add(reader.GetName(count), reader[count]);
                                }
                                result.Add(dict);
                            }
                        }
                        return result;
                    }
                    catch (ApplicationException ex)
                    {
                        throw new ApplicationException("Error Executing " + sql, ex);
                    }
                    finally
                    {
                        cmd.Connection.Close();
                    }
                }
            }
        }
