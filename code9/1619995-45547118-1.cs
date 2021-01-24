	void Main()
	{
		HandlingMyFuncAsync();
		Console.WriteLine("Doing some work, while 'fire and forget job is performed");
		Console.ReadLine();
	}
	
	public void HandlingMyFuncAsync()
	{
		var task = MyFuncAsync();
		task.ContinueWith(t => Console.WriteLine(t), TaskContinuationOptions.OnlyOnRanToCompletion);
	}
	
	public async Task<string> MyFuncAsync()
	{
		await Task.Delay(5000);
		return "A";
	}
