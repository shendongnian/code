	using(var Context = new YourDbContext())
	{
		// the Select expression is optional, if you have many properties on the model that are not used it can 
		// increase efficiency to only pull back what you are going to write to the stream
		foreach(var record in Context.Reg.AsNoTracking().Select(x => new {x.FirstName, x.LastName, x.City /* etc */ }))
		{
			var stringToWrite = string.Join(",", record.FirstName, record.LastName, record.City /* etc. */);
			// write the string to a stream or output
		}
	}
