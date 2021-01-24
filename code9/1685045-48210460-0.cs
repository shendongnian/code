    using(var con = new SqlConnection(connectionString))
    {
        using(var cmd = new SqlCommand(sql, con))
        {
            // prepare command here - parameters and stuff like that
            
            // either
            using(var reader = cmd.ExecuteReader())
            {
            }
            // or 
            using(var adapter = new SqlDataAdapter(cmd))
            {
            }
        }
    }
 
