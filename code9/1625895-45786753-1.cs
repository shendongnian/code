    using(SqlConnection connection = new SqlConnection(yourConnectionString))
    {
        String query = "INSERT INTO electric (h1, h2, h3, h4) VALUES (@h1, @h2, @h3, @h4)";
        using(SqlCommand command = new SqlCommand(query, connection))
        {
           int h1Data = 0;
           Int32.TryParse(h1TextBox.Text, out h1Data);
           int h2Data = 0;
           Int32.TryParse(h2TextBox.Text, out h2Data);
           int h3Data = 0;
           Int32.TryParse(h3TextBox.Text, out h3Data);
           int h4Data = 0;
           Int32.TryParse(h4TextBox.Text, out h4Data);
           command.Parameters.AddWithValue("@h1", h1Data);
           command.Parameters.AddWithValue("@h2", h2Data);
           command.Parameters.AddWithValue("@h3", h3Data);
           command.Parameters.AddWithValue("@h4", h4Data);
           connection.Open();
           int result = command.ExecuteNonQuery();
           // Check Error
           if(result < 0)
           {
              // Error
           }
        }
    }
