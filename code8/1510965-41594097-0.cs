    public DataTable RunQuery(string query)
    {
    //connectionString should come from your configuration or a constant that is a part of this class
       DataTable dt = new DataTable();
       using (SqlCommand cmd = new SqlConnection(connectionString))
            {
            
                cmd.CommandText = query;
                cmd.Connection.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                     sda.Fill(dt);
                }
                cmd.Connection.Close();
            }
       return dt;    
    }
