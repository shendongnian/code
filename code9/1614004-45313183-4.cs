    public void CreateSubscription()
    {
	    var cachCleanTimer = Observable.Interval(TimeSpan.FromMinutes(2));
	    cachCleanTimer.Take(1).Subscribe(CheckUploadSetList); // Stop after the first item
    }
    public void UploadDicomSet()
    {
	    CreateSubscription();
	    // Do other things
    }
    
    void CheckUploadSetList(long interval)
    {
	    Console.WriteLine(interval);
	    // Do other things
    }
    public void AddDicomFile(SharedLib.DicomFile dicomFile)
    {
	    CreateSubscription();
	    // Do other things
    } 
