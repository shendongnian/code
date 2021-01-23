		var someNumbers = new [] { 10,67,45,26,78,53,12,45,68};
		var groupNames = new [] { "A", "B", "C", "D" };
		
        //                               Key                      Value
		var result = someNumbers.GroupBy(v => groupNames[v / 25], p => p);
		
		foreach(var v in result.OrderBy(i => i.Key))
		{
			Console.WriteLine(v.Key);
			foreach(var k in v)
				Console.WriteLine("  " + k);
		}
