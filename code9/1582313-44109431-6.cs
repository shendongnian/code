    	public static void Main()
    	{
    		var s = System.Diagnostics.Stopwatch.StartNew();
    		
    		var N = 1000;
    		var rate = 300.0;
    		
    		var gen = Enumerable.Range(0,N).Select(i =>{
    
    			return (Func<Task>) (async ()=>{
    
    				await Task.Delay(TimeSpan.FromSeconds(0.00001));
    				Console.WriteLine(DateTime.Now);
    			});
    		});
    		
    		RateLimit(gen,rate).Wait();
    		
    		Console.WriteLine("Elapsed Seconds " + s.Elapsed.TotalSeconds);
    		Console.WriteLine("Expected Elapsed Seconds " + N/rate);
    	}
    }
