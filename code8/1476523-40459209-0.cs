	MySqlConnection conn = new MySqlConnection(connectionstring);
	MySqlCommand cmd = new MySqlCommand();
	cmd.CommandType = CommandType.StoredProcedure;
	cmd.CommandText = "viewByCat";
	cmd.Parameters.AddWithValue("@keywords", ComboBox.Text);
	cmd.Parameters["@keywords"].Direction = ParameterDirection.Input;
	MySqlDataReader myReader;
	myReader = cmd.ExecuteReader();
	try
	{
		while(myReader.Read())
		{
			Console.WriteLine(myReader.GetString(0));
		}
	}
	finally
	{
		myReader.Close();
		myConnection.Close();
	}
