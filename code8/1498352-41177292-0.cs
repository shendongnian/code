    string queryStr = "SELECT ipaddress FROM webappdemo.userregistration WHERE username=@username";
    using (MySqlConnection conn = new MySqlConnection(connString))
    {
        conn.Open();
        using (MySqlCommand cmd = new MySqlCommand(queryStr, conn))
        {
            cmd.Parameters.AddWithValue("@username", username);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBoxIPAddress.Text = reader["ipaddress"].ToString();
            }
        }
    }
