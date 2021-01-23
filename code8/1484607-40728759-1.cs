	Range<DateTime> a = new Range<DateTime>(DateTime.Now.AddDays(-20), DateTime.Now);
	Console.WriteLine(a.AsString);
	Console.WriteLine(Range<DateTime>.Parse("2016-11-01T19:38:05.6409410+00:00,2016-11-21T19:38:05.6409410+00:00").AsString);
	
	Range<int> b = new Range<int>(37, 42);
	Console.WriteLine(b.AsString);
	Console.WriteLine(Range<int>.Parse("37,42").AsString);
