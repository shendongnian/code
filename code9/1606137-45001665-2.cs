	public async Task ImportAsyncData()
	{
	    var gs = new Site();
		
	    int requestDid = 0;
	    int requestDone = 0;
	    var found = 0;
	    
		var watch = System.Diagnostics.Stopwatch.StartNew();
	    var start = 4000000;
	    var end = start + 100000
	    
		var cod = "user"
	    
		for (int i = start; i < end; i++)
	    {
	        var ts = watch.Elapsed;
	        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
	            ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
	
	        Console.Title = "R: " + (i - start) + " F: " + found + " EL: " + ts;
	
	        var c = cod + i;
	
	        var user = await gs.GetAsync(c);
			if (user == null)
			{
				requestDone++;
				return;
			}
			
			using (var db = new Database())
	        {
	            found++;
	            db.InsertUser(user);
	        }
	
	        requestDid++;
	    }
	}
