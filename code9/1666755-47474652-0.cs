        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("myStoredProcedure"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
    
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@param1", value1);
                        cmd.Parameters.AddWithValue("@param2", value2);
                        cmd.Parameters.AddWithValue("@param3", value3);
                        cmd.Connection = con;
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                            {
                                DataRow dr = dt.NewRow();
                                dr[0] = reader[0].ToString();
                                dr[1] = reader[1].ToString();
                                dr[2] = reader[2].ToString();           
                                dt.Rows.Add(dr);
                            }
                        return true;
                    }
                }
            }
        }
        catch(Exception e)
        {
    
            return false;          
        }
