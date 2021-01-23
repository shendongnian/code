	void Seq()
	{
		foreach (var line in File.ReadLines(fname))
		{
			Process(line);
		}
	}
	void Parallel1()
	{
		Parallel.ForEach(File.ReadLines(fname), line=>Process(line));
	}
	void Parallel2()
	{
		var list = new List<string>();
		var tasks = new List<Task>();
		
		foreach (var line in File.ReadLines(fname))
		{
			list.Add(line);
			if (list.Count > 1000)
			{
				var local = list;
				list = new List<string>();
				tasks.Add(Task.Run(()=>local.ForEach(x=>Process(x))));
			}
		}
		
		tasks.Add(Task.Run(()=>list.ForEach(x=>Process(x))));
		
		Task.WaitAll(tasks.ToArray());
	}
