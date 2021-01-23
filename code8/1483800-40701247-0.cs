    public Task<string> ReadData(int i)
    {
    	TaskCompletionSource<string> tcs = new TaskCompletionSource<string>();
    	var client = new WebClient();
    	string uriString = @"http://someforum.com/page?id=" + i;
    	client.DownloadStringCompleted += (sender,args) =>
    	{
    		 tcs.TrySetCanceled();
    		 tcs.TrySetException(args.Error);
    		 tcs.TrySetResult(args.Result);
    	};
    	
    	client.DownloadStringAsync(new Uri(uriString));
    	
    	return tcs.Task;
    }
