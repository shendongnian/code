	public MyClass()
	{
		... // Your stuff goes here
        Initialize();
	}
    private async void Initialize()
    {
        Task.Run(async () => 
		{
			await ServerObjectReference.AsyncMethod();
		});
    }
