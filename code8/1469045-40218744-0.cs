	public void getCountUsers()
	{
		EventLog myNewLog = new EventLog();
		myNewLog.Log = "Security";
		
		var query =
			from EventLogEntry entry in myNewLog.Entries
			where entry.InstanceId == 4624
			where entry.TimeWritten.Date == DateTime.Today
			where new[] { "192", "127" }.Any(x => entry.ReplacementStrings[18].Contains(x))
			select new { entry.TimeWritten.Hour, User = entry.ReplacementStrings[5] };
		
		var result =
			query
				.GroupBy(x => x.Hour, x => x.User)
				.OrderByDescending(x => x.Count())
				.Take(1)
				.Select(x => new
				{
					Hour = x.Key,
					Users =
						x
							.GroupBy(y => y)
							.Select(y => new Users(y.Count(), y.Key))
							.ToList()
				})
				.First();
		
		Hour = result.Hour;
		UserList = result.Users;
		
	}
