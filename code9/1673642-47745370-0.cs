    static async void Main()
    {
    	Console.WriteLine(await A());
    }
    
    static async Task<int> A()
    {
    	return await B();
    }
    
    static async Task<int> B() 
    {
    	await Task.Delay(1);
    	return 1;
    }
