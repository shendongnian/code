       try
        {
            using (MySqlDataReader reader = db.SelectCategory())
            {
                while (reader.Read())
                {
                    listBox1.Items.Add(reader.GetString(1));
                }
            }
            db.CloseConnection(); // will be the method to close the connection
        }
