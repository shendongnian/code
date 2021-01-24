	public SQLite.Net.Async.SQLiteAsyncConnection GetConnectionAsync ()
	{
		var connectionFactory = new Func<SQLite.Net.SQLiteConnectionWithLock>(()=>
				new SQLite.Net.SQLiteConnectionWithLock(new SQLitePlatformWinRT(),
						new SQLite.Net.SQLiteConnectionString(DbPath, storeDateTimeAsTicks: false)));
		var asyncConnection = new SQLiteAsyncConnection(connectionFactory);
		return asyncConnection;
	}
