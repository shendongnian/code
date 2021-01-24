    public DataTable SelectAll(string procName, SqlParameter[] para = null)
            {
                DataTable dt = new DataTable();
                try
                {
                    using (SqlConnection con = new SqlConnection(connString))
                    {
                        con.Open();
    
                        using (SqlCommand cmd = new SqlCommand(procName, con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            if (para != null)
                                cmd.Parameters.AddRange(para);
    
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                
                                da.Fill(dt);
                            }
                        }
                    }
                }
                catch (Exception sqlEx)
                {
                    Console.WriteLine(@"：Unable to establish a connection: {0}", sqlEx);
                }
    
                return dt;
    
            }
