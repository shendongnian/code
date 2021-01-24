	var test = session.Query<Entity>()
		.GroupBy(e => 
            new
            {
                e.YourDate.Date,
                e.YourDate.Hour,
                e.YourDate.Minute,
                threeSec = e.YourDate.Second / 3
            })
		.Select(g =>
            new {
                g.Key.Date,
                g.Key.Hour,
                g.Key.Minute,
                g.Key.threeSec,
                avg = g.Average(e => e.YourNumeric)
            })
		.ToList();
