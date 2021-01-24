	var xs = new[] {
		new TimePeriod() { Start = new DateTime(2017, 1, 1), End = new DateTime(2018, 1, 1) },
		new TimePeriod() { Start = new DateTime(2018, 1, 1), End = new DateTime(2019, 1, 1) }
	};
	var ys = new[] {
		new TimePeriod() { Start = new DateTime(2017, 10, 1), End = new DateTime(2017, 11, 1) },
		new TimePeriod() { Start = new DateTime(2018, 1, 1), End = new DateTime(2019, 1, 1) }
	};	
	var us = xs.Union(ys, new TimePeriodEqualityComparer());
	foreach (var u in us) {
		Console.WriteLine(u);
	}
