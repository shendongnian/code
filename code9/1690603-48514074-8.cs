    //"GetLinesAsync" already exists.  How can I use it?
   
    [TestMethod]
    public async Task ReactiveTest2()
    {
    	var combined2 = Observable.Create<string>(async observer =>
    	{
    		var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "win.ini");
    
    		using (FileStream readFile = File.OpenRead(filePath))
    		{
    			using (StreamReader reader = new StreamReader(readFile))
    			{
    				await GetLinesAsync(reader)
    					.ForEachAsync(result => observer.OnNext(result));
    			}
    		}
    	});
    
    
    	int count = await combined2.Count();
    }
