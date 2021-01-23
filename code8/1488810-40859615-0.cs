    try
    {
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
                        // ..or return a List<string> if you want to split that
                        listBox1.Items.Add(reader.GetString(1));
                    }
                }
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
