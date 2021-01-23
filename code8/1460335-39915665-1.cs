	void NotReallyButGoodOne()
	{
		var tasks = new List<Task>();
		for (var i = 0; i < 10; i++)
		{		
			tasks.Add(Task.Run(()=>CallAPI()));
		}
		
		Task.WaitAll(tasks.ToArray());
	}
