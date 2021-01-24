    using (SqlConnection con = new SqlConnection(connectionString))
    {
       using (SqlCommand command = new SqlCommand("your query", con))
       {
        // output processing
       }
    }
