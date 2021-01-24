    public void ProcessImages(string imageFolderPath)
    {
    	FileInfo[] files = ...
    	
    	foreach (var batch in files.Batch(10))
    	{
    		var stopWatch = new System.Diagnostics.Stopwatch();
    		stopWatch.Start();
    		
            //Process the files as before, but now only 10 at a time
            ProcessBatch(batch);
    		stopWatch.Stop();
    		
            //If less than 1 second has passed, let's hang around until it has
    		if(stopWatch.ElapsedMilliseconds < 1000)
    		{
                //Probably don't use Thread.Sleep here, but you get the idea
    			Thread.Sleep(1000 - (int)stopWatch.ElapsedMilliseconds);
    		}
    	}
    }
    private void ProcessBatch(IEnumerable<FileInfo> batch)
    {
		//Process the batch as before
		var tasks = new List<Task>();
        foreach (FileInfo file in batch)
        {
            tasks.Add(MakeAnalysisRequest(file.FullName, file.Name, delay, subscriptionKey, endPointURL));
        }
        //Waiting for "MakeAnalysisRequest" to finish.
        Task.WaitAll(tasks.ToArray());
    }
