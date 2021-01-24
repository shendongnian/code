    using (SqlConnection connection = new SqlConnection(...))
    {
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            // the code using reader
        }
    }
