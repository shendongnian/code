    //assuming reader is defined
	reader = MySqlHelper.ExecuteReader(connString, query, new MySqlParameter[] {
									new MySqlParameter("?username", username) 
								}));
    while (reader.Read()) //read from the reader
    {
        textBoxIPAddress.Text = reader["ipaddress"].ToString(); 
    }
