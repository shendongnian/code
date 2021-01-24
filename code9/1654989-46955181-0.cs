     try
                {
                    using (SqlConnection conn = new SqlConnection("your Connection string"))
                    {
                        conn.Open();
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                             cmd.CommandText = @"INSERT INTO TestTable 
											    	(Type,Serialnumber )
													VALUES (@type,@serialnumber)";
                           
                            cmd.Parameters.AddWithValue("@type", type);
                            cmd.Parameters.AddWithValue("@serialnumber", serialnumber);
                            
                            int rows = cmd.ExecuteNonQuery();
                            if (rows == 0)
                                throw new Exception("Nothing Inserted into the DB");
                          
                            cmd.ExecuteNonQuery();
                            
                }
                catch (Exception ex)
                {
				}
