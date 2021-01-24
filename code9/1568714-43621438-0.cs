    using (SqlConnection connection  = new SqlConnection(_customerContext.Database.Connection.ConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand("dbo.usp_CustomerAll_sel", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
        
                        cmd.Parameters.Add(new SqlParameter("@SomeOutput", SqlDbType.BigInt) { Direction = ParameterDirection.Output, Value = -1 });
        
                        if (cmd.Connection.State != ConnectionState.Open)
                        {
                            cmd.Connection.Open();
                        }
        
        
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
        
                        long SomeOutput = (long)cmd.Parameters["@SomeOutput"].Value;
        
                        connection.Close();
                    }
