    public List<string> SelectCategory()
    {
        List<string> result = new List<string>();
        string Command = "SELECT * FROM categories WHERE online = 1";
        using (MySqlConnection mConnection = new MySqlConnection(ConnectionString))
        {
            mConnection.Open();
            using (MySqlCommand cmd = new MySqlCommand(Command, mConnection))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {                        
                        result.Add(reader.GetString(1));
                    }
                }
            }
        }
        return result;
    }
