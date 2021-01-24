	private IEnumerable<StatsticsVm> GetStatsticsPerDay(StatsticsQueryModel sqm)
	{
		var messages = GetMessagesByDateAndIU(sqm);
	
		var f = new DateTime(sqm.From.Year, 1, 1);
		var t = new DateTime(sqm.To.Year + 1, 1, 1);
	
		var lookup = messages.ToLookup(x => x.ObservationDateTime.Date);
	
		IEnumerable<StatsticsVm> messagesCountPerDay =
			from n in Enumerable.Range(0, t.Subtract(f).Days)
			let day = f.AddDays(n)
			select new StatsticsVm()
			{
				Label = day.ToString(@"d/m/y"),
				MessagesCount = lookup[day].Count()
			};
	
		return messagesCountPerDay;
	}
