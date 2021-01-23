    using (SqlCommand cmd = new SqlCommand("sp_db",
                new SqlConnection("your_db_connection")))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@param", SqlDbType.VarChar).Value = param;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string a = (string)reader["ATTRIBUTE_A"];
                        string b = (string)reader["ATTRIBUTE_B"];
                    }
                }
            }
