    using (MySqlConnection conn = new MySqlConnection())
    using (MySqlCommand cmd = conn.CreateCommand())
    {
        try
        {
           conn.Open();
           ... rest of the code goes here
        }
    }
