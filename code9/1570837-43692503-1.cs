	public MyContext : DbContext
	{
		private static ILog log = LogManager.GetCurrentClassLogger();
		public MyContext(string connectionString)
			: base(connectionString)
		{
			this.Database.Log = (msg) => 
			{
				if (msg.Contains("@'Brunswick'"))
					Debugger.Break();
			};
		}
	}
