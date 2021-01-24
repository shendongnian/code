	public IObservable<MyStreamItem> StreamData(SomeRequestData request)
	{
		return Observable.Defer(() =>
		{
	    	if (!IsValid(request))
	    	{
		        return Observable.Throw<MyStreamItem>(new Exception("Invalid Request"));
		    }
			else
				//return observable when request is valid
		});
	}
