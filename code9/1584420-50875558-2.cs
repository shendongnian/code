	var factory = new SqlServerDbConnectionFactory(connectionString);
	CustomDbProfiler cp = new CustomDbProfiler();
	using(var connection = DbConnectionFactoryHelper.New(factory, cp))
	{
		//DB Code
	}
	string log = cp.ProfilerContext.GetCommands();
