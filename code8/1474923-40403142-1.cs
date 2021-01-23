	public enum DBType { SQLite, SQLServerCe };
	public static DBType GetDatabaseType(string filename)
	{
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
			return DBType.SQLite;
		}
		else
		{
			return DBType.SQLServerCe;
		}
	}
	public static int[] ImportDB_Verify()
	{
		string dbFilePath = "someDatabaseFile"
		DBType detectedType = GetDatabaseType(dbFilePath);
		
		if(detectedType == DBType.SQLite)
			return VerifySQLiteDb(dbFilePath);
		else
			return VerifySQLServerCeDb(dbFilePath);
	}
	private static int[] VerifySQLiteDb(string dbFilePath)
	{
		//...
		// exception handling etc.
	}
	private static int[] VerifySQLServerCeDb(string dbFilePath)
	{
		//...
		// exception handling etc.
	}
