	List<string> originalList = new List<string>()
	{
		@"AAA\BBB",
		@"AAA\CCC",
		@"AAA\CCC",
		@"BBB\XXX",
		@"BBB",
		@"BBB\XXX",
		@"BBB\XXX"
	};
	List<string> outputList = new List<string>();
		
	foreach(var g in originalList.GroupBy(x => x).Select(x => x.ToList()))
	{		
		for(int i = 0; i < g.Count; i++)
		{
			outputList.Add(string.Format("{0}[{1}]", g[i], i + 1));
		}
	}
