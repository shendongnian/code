    IDisposable subscription;
    public void CreateSubscription()
    {
	    var cachCleanTimer = Observable.Interval(TimeSpan.FromMinutes(2));
        if(subscription != null)
		    subscription.Dispose();
	    subscription = cachCleanTimer.Subscribe(CheckUploadSetList);
    }
    public void UploadDicomSet()
    {
	    CreateSubscription();
	    // Do other things
    }
    
    void CheckUploadSetList(long interval)
    {
        subscription.Dispose(); // Stop the subscription
	    Console.WriteLine(interval);
	    // Do other things
    }
    public void AddDicomFile(SharedLib.DicomFile dicomFile)
    {
	    CreateSubscription();
	    // Do other things
    } 
