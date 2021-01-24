    public static IObservable<HttpResponseMessage> CheckForApiErrors2(this IObservable<HttpResponseMessage> source)
    {
    	return source.SelectMany(message => message.IsSuccessStatusCode
    		? Observable.Return(message)
    		: Observable.FromAsync(() => ApiException.CreateFromHttpMessage(message)).SelectMany(Observable.Throw<HttpResponseMessage>
    	)
    }
    
    public static IObservable<HttpResponseMessage> CheckForApiErrors3(this IObservable<HttpResponseMessage> source)
    {
    	return source.Publish(_source => _source
    		.Where(message => message.IsSuccessStatusCode)
    		.Merge(_source
    			.Where(message => !message.IsSuccessStatusCode)
    			.SelectMany(message => Observable.FromAsync(() => ApiException.CreateFromHttpMessage(message)).SelectMany(Observable.Throw<HttpResponseMessage>))
    		)
    	);
    }
