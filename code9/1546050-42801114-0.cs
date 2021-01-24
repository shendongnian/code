	using (var dbContext = new ApplicationDbContext())
	{
		dbContext.Configuration.LazyLoadingEnabled = false;
		var list = dbContext.Videos.Take(5).ToList();
		var output = JsonConvert.SerializeObject(list);
	}
