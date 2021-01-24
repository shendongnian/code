    using(SqlConnection conn = objcon.CreateConnection())
    {
        // create SqlCommand and pass conn!
        using(SqlCommand cmd = new SqlCommand("select * from Employee", conn))
        {
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
            // and the rest of your rdr reading code
            }
        }
    }
    
