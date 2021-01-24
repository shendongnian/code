	using (var context = new YourModel())
	{
		var e = context.YourTable.Create();
		e.Id = guid;
        // ...etc
		e.Timestamp = timestamp;
		context.YourTable.Add(e);
		context.SaveChanges();
	}
