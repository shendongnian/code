    private void AcceptData(string connectionString)
    {
        using (SqlConnection Connection = new SqlConnection(connectionString))
        {
            Connection.Open(); // open the connection before using adapter
            using (SqlDataAdapter adapter = new SqlDataAdapter("INPUT INTO Person", Connection))
            {
                // other stuff
            }
        }
    
        // other stuff
    }
