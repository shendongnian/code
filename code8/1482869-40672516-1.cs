    int valid = -1;            
    using (MySqlConnection cnn = new MySqlConnection(conString))
        {
            cnn.Open();
            bool usernameExists = false;
            MySqlCommand cmd1 = new MySqlCommand("SELECT Username FROM Users WHERE Username = @username LIMIT 1", cnn);
            cmd1.Parameters.AddWithValue("@username", username);
            usernameExists = (int)cmd1.ExecuteScalar() > 0;
            if (!usernameExists)
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO Users(Username, Password) VALUES(@username, @password)", cnn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                valid = cmd.ExecuteNonQuery();
            }
        }
    return valid;
