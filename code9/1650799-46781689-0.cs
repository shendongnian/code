    public IObservable<string> SendNetworkRequestObservable(string requestType)
    {
    	return Observable.Create<string>(observer =>  
    	{
    		SendNetworkRequest(requestType, s => observer.OnNext(s));
    		observer.OnCompleted();
    		return Disposable.Empty;
    	});
    }
    
    // Define other methods and classes here
    public void SendNetworkRequest(string requestType, Action<string> callback)
    {
    	callback(requestType); // implementation for testing purposes
    }
