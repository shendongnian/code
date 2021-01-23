	using (var ctx = new MyDbContext())
	{
		// Do your thing...
		// Call ctx.SaveChanges();
	}
	using (var ctx = new MyDbContext())
	{
		// Do your thing...
		// You should not find the data anymore
	}
