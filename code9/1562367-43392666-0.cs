    string connectionstring = @"****;userid=*****;
    password=***;database=***";
    cnn = new MySqlConnection(connectionstring);
    cnn.Open();
    
    string query_date = "SELECT computer_name AS `computer_name` FROM wp_users WHERE user_login = @login";
    
    MySqlCommand command2 = new MySqlCommand(query_date, cnn);
    command2.Parameters.AddWithValue("@login", metroTextBox.Text);
    
    DataTable table = new DataTable("ResultTable");
    MySqlDataAdapter adapter = new MySqlDataAdapter(command2);
    adapter.Fill(table);
    
    // This is the important line
    string result = table["computer_name"];
    
    cnn.Close();
