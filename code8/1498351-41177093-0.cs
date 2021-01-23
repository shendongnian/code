    try
    {
        string query = "SELECT ipaddress FROM webappdemo.userregistration WHERE username = @username";
        string connString =ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
        using(MySqlConnection connection = new MySqlConnection(connString))
        {
            using(MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.Add("@username", username);
    
                connection.Open();
                object ip= command.ExecuteScalar();
                if (ip != null) {
                  textBoxIPAddress.Text = ip.ToString();
                }
            }
        }
    }
    catch(MySqlException ex)
    {
        // do something with the exception
    
    }
