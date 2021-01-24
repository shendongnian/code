            try
            {
                using (System.IO.StreamWriter ff = new System.IO.StreamWriter(fileName))
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(
                        @"SELECT
                          firstName, 
                          lastName,
                          salary
                          FROM persons",
                        connection);
                    connection.Open();
                    ff.WriteLine("firstName,lastName,salary");  // header
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var rr = (IDataRecord)reader;
                        ff.WriteLine(string.Format("{0},{1},{2:C2}",
                                                     rr.GetValue(0),
                                                     rr.GetValue(1),
                                                     rr.GetValue(2)                                                    
                                                   )
                                    );
                    }                    
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
