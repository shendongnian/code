    using (SqlConnection con = new SqlConnection(connectionString))
    {
       con.Open();
       using (SqlCommand command = new SqlCommand("your query", con))
       {
        // output processing
       }
    }
