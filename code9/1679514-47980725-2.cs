	using (var db = new SMBASchedulerEntities("DefaultConnection1"))
	{
		// use MyDatabase1 through connection string "DefaultConnection1"
	}
	
	using (var db = new SMBASchedulerEntities("DefaultConnection2"))
	{
		// use MyDatabase2 through connection string "DefaultConnection2"
	}
