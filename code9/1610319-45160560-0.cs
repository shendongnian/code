	var cals = new []
	{
	 	new { ParentId = 1, StartDate = DateTime.Parse("2017-06-18 11:50:00"), EndDate = DateTime.Parse("2017-06-18 12:20:00") },
		new { ParentId = 2, StartDate = DateTime.Parse("2017-06-18 12:10:00"), EndDate = DateTime.Parse("2017-06-18 12:40:00") },
		new { ParentId = 3, StartDate = DateTime.Parse("2017-06-18 12:15:00"), EndDate = DateTime.Parse("2017-06-18 12:45:00") },
	};
	
	var intersection =
		cals
			.Aggregate((c0, c1) => new
			{
				ParentId = -1,
				StartDate = c0.StartDate > c1.StartDate ? c0.StartDate : c1.StartDate,
				EndDate = c0.EndDate < c1.EndDate ? c0.EndDate : c1.EndDate
			});
