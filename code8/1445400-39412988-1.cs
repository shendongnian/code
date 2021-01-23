	string cs4 = ConfigurationManager.ConnectionStrings["example"].ConnectionString;
	using (SqlConnection con4 = new SqlConnection(cs4))
	using(StreamWriter file4 = new StreamWriter(@"\\Desktop" + todaysDate + ".csv"))
	{
		string strTQuery = @"SELECT A, B, C, D FROM [dbo].[view]";
		var command = new SqlCommand(strTQuery, con4);
		con4.Open();
		var reader = command.ExecuteReader();
		
		while(reader.Read())
		{
			file4.Write(reader.GetString(0) + strDelimiter);
			file4.Write(reader.GetString(1) + strDelimiter);
			file4.Write(reader.GetString(2) + strDelimiter);
			file4.Write(reader.GetString(3));
			file4.Write("\r\n");
		}
	}
