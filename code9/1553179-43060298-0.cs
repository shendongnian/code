    static void Main(string[] args)
    {
    
    	Class1 testcla = new Class1();
    	testcla.test();
    
    	Console.WriteLine("Wait for async task to finish.");
    	Console.ReadLine();
    }
    		
    class Class1
    {
    	public void test()
    	{
    		test1();
    	}
    
    	public async void test1()
    	{
    		await test2();
    	}
    
    	public async Task<string> test2()
    	{
    		try
    		{
    			WebClient testwc = new WebClient();
    			var content = await testwc.DownloadStringTaskAsync("http://www.yahoo.com");
    			Console.WriteLine("Length of content received: " + content.Length.ToString());
    			return content;
    		}
    		catch (Exception ex)
    		{
    			Console.WriteLine(ex.Message);
    			return null;
    		}
    		finally
    		{
    			Console.WriteLine("Async task done. Press enter to exit.");
    		}
    	}
    }
