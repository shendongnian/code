	public MyClass()
	{
		... // Your stuff goes here
		
		Task.Run(async () => 
		{
			await ServerObjectReference.AsyncMethod();
		});
	}
