	while (reader.Read())
	{
        // Build the line you want to write
		string lineToWrite = reader["Item1"].ToString() + reader["Item2"].ToString();	
        // Write the line without carriage return
		writer.Write(lineToWrite);
		
		if (reader.HasRows)
		{
			writer.WriteLine();
		}
	}
