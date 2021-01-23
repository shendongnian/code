    const string test1 = "Test1";
	const string test2 = "test1";
	
	var s1 = new Stopwatch();
	s1.Start();
	
	for (int i = 0; i < 1000000; i++)
	{
		if (!(test1.ToUpper() == test2.ToUpper()))
		{
			var x = "1";
		}
	}
	s1.Stop();
	s1.ElapsedMilliseconds.Dump();
	var s2 = new Stopwatch();
	s2.Start();
	for (int i = 0; i < 1000000; i++)
	{
		if(!string.Equals(test1, test2,
			   StringComparison.OrdinalIgnoreCase))
        {
			var x = "1";
		}
	}
	s2.Stop();
	s2.ElapsedMilliseconds.Dump();
