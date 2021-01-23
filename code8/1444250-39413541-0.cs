    public async Task Load(int id)
    {
    	Task asynctask1;
    	asynctask1 = CallWithAsync(id); // this is async task 
    	task2(); // main thread
    	task3(); // main thread
    	var result = await asynctask1;
        Console.Writeline(result); //verify returned value of asynctask1 task 
    }
    
    private async static Task<string> CallWithAsync(int id)
    {
    	string result = "";
    	try
    	{
    		result = await InsertDataAsync(id);
    	}
    	catch (Exception ex)
    	{
    		//do some error logging
    	}
    	return result;
    
    }
