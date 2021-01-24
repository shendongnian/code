	// Read the file content from the function parameter.
	string content = System.Text.Encoding.ASCII.GetString(bytes);
	// Split the content into an array where each array item is a line for
	// each row of data.
	string[] data = content.Replace("\r\n", "|").Split('|');
	// Loop through each row and extract the data you want.
	// Note that each value is in a fixed position in the row.
	foreach (string row in data)
	{
		if (!String.IsNullOrEmpty(row))
		{
			string[] cols = row.Split(';');
			List<MySqlParameter> args = new List<MySqlParameter>();
			args.Add(new MySqlParameter("@sid", Session["storeid"]));
			args.Add(new MySqlParameter("@name", cols[0]));
			args.Add(new MySqlParameter("@con", cols[3]));
			try
			{
				// Insert the data to the database.
			}
			catch (Exception ex)
			{
				// Report an error.
			}
		}
	}
