    private void AcceptData()
    {
        // assumed the connection string obtained from app.config or web.config file
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;
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
