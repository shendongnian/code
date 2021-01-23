    public IObservable<string> Convert()
    {
        return Observable.Create<string>(observer=>
        {
            //do stuff here.
            //Call observer.OnNext with status messages
            //When done call observer.OnCompleted()
        });
    }
