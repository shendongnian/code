    public Task CreateDownloader(ConcurrentQueue<string> queue, CancellationToken token, 
    	TimeSpan interval, Action<string, string> continuation)
    {
    	return Task.Run(async () =>
    	{
    		while (!token.IsCancellationRequested)
    		{
    			string url;
    			if (queue.TryDequeue(out url))
    			{
    				try
    				{
    					var result = await MockDownloader.Download(url);
    					continuation(url, result);
    				}
    				catch (Exception)
    				{
    					// Implement exception handling and logging here.
    					// Optionally, you can also pass in how to handle these.
    				}
    				queue.Enqueue(url);
    			}
    			await Task.Delay(interval);
    		}
    	});
    }
