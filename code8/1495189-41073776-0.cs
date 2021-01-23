    async Task Main()
    {
    	var finalResult = await AsyncQuery();
    	Console.WriteLine(finalResult);
    }
    
    public async Task<int> AsyncQuery()
    {
    	var result = GetAsyncDepartments();
    	Debug.WriteLine("Do some stuff here");
    	return await result;
    }
    
    public async Task<int> GetAsyncDepartments()
    {
    	Console.WriteLine("Starting GetAsyncDepartments");
    	await Task.Delay(5000);
    	Console.WriteLine("Finished GetAsyncDepartments");
    	return 5;
    }
