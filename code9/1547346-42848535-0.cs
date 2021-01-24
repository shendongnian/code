    public string GetNextApplicationNumber(int applicationId)
            {
                DataTable dt = new DataTable();
                try
                {
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();
    
                        using (SqlDataAdapter da = new SqlDataAdapter("GetNextApplicationNumber", conn))
                        {
    
                            da.SelectCommand.Parameters.AddWithValue("@ApplicationId", applicationId);
                            da.SelectCommand.CommandType = CommandType.StoredProcedure;
                            da.Fill(dt);
    
                            string applicationNumber = string.Empty;
    
                            applicationNumber = dt.Rows[0]["Column_Name"].ToString();
    
                            return applicationNumber;
                        }
                    }
                }
                catch
                {
                    throw;
                }
            }
