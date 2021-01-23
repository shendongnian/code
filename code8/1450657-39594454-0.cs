	public async Task DoProcessingAsync()
	{
		var task1 = Task.Run(Process1);
		var task2 = Task.Run(Process2);
		var result = await Task.WhenAll(task1, task2);
		var finalResult = task1.Result.Concat(task2.Result).ToList();
	}
	
	private List<DataPoint> Process1()
	{
		return new List<DataPoint>();
	}
	
	private List<DataPoint> Process2()
	{
		return new List<DataPoint>();
	}
