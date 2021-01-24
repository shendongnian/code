    using (MySqlConnection AR = new MySqlConnection())
    {
        AR.Open();
        String query = "SELECT MessageNumber FROM ncslbpHighWay ORDER BY [ColumnName] DESC LIMIT 1";
        using (MySqlCommand SDA = new MySqlCommand(query, AR))
        {
            MySqlDataReader data = SDA.ExecuteReader();
            if (data.Read())
            {
                textBox2.Text = data.GetValue(0).ToString();
            }
        }
        AR.Close();
    }
