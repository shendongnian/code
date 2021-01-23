	byte[] buffer = new byte[4];
	using (var fileStream = File.OpenRead(databasefile))
	{
		fileStream.Read(buffer, 0, 4);	
	}
	if (buffer[0] == 83 // S
		&& buffer[1] == 81 // Q
		&& buffer[2] == 76 // L
		&& buffer[3] == 105) // i
	{
		// SQLite
	}
	else
	{
		// Assume SQL Server CE
	}
