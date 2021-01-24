            bool nameExists;
            connection statement
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText =
                    @"SELECT TOP 1 Enabled " +
                    @"FROM [dbo].[products] p WITH (NOLOCK) " +
                    @"WHERE [p].[name] = @name";
                command.Parameters.AddWithValue("name", name);
                command.CommandTimeout = 100;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    nameExists = reader.HasRows;
                    if (nameExists)
                    {
                        reader.Read();
                        //bool Enabled = (reader.GetInt32(0) == 1);
                        bool Enabled = reader.GetBooean(0);
                        if (Enabled)
                            return "Data exist in the table";
                        else
                            return "Data is disabled.";
                    }
                    else
                    {
                        throw new Exception ("Data not exist in the table");
                    }
                }
                connection.Close();
            }
