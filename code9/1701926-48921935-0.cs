    MySqlCommand command2 = new MySqlCommand("SHOW WARNINGS", con);
    using (MySqlDataReader reader = command2.ExecuteReader())
    {
        while (reader.Read())
        {
            String level = reader["Level"].ToString();
            String code = reader["Code"].ToString();
            String message = reader["Message"].ToString();
        }
    }
