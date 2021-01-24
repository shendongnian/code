    class Program
    {
    	static Task[] tasks = new Task[3];
    	static HttpClient _client = new HttpClient();
    
    	static void Main(string[] args)
    	{
    		Console.WriteLine("Main start");
    		Task t = Run();
    		t.ContinueWith((str) =>
    		{
    			Console.WriteLine(str.Status.ToString());
    			Console.WriteLine("Main end");
    		});
    		t.Wait();
    	}
    
    	public static async Task Run()
    	{
    		tasks[0] = GetMyData("http://www.w3.org/TR/PNG/iso_8859-1.txt");
    		tasks[1] = GetMyData("http://www.w3.org/TR/PNG/iso_8859-1.txt");
    		tasks[2] = GetMyData("http://www.w3.org/TR/PNG/iso_8859-1.txt");
    		
    		await Task.WhenAll(tasks);
    
    		var result4 = (await (Task<Stream>)tasks[2]);
    	}
    
    	public static async Task<Stream> GetMyData(string urlToCall)
    	{
    		return await _client.GetStreamAsync(urlToCall);
    	}
    }
