                    string myString;
                    using (SqlDataReader rdr = command.ExecuteReader())
                    {
                        do
                        {
                            while (rdr.Read())
                            {
                                myString = rdr.GetString(0);
                            }
                        } while (rdr.NextResult());
                    }
