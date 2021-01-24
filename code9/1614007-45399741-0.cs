	public class UploadDicomSet : ImportBaseSet
	{
	    IDisposable subscription;
		Subject<IObservable<long>> subject = new Subject<IObservable<long>>();
		
	    public UploadDicomSet()
	    {
	        subscription = subject.Switch().Subscribe(s => CheckUploadSetList(s));
			subject.OnNext(Observable.Interval(TimeSpan.FromMinutes(2)));
	    }
	
	    void CheckUploadSetList(long interval)
	    {
	        subject.OnNext(Observable.Never<long>());
	        // Do other things
	    }
	
	    public void AddDicomFile(SharedLib.DicomFile dicomFile)
	    {
	        subject.OnNext(Observable.Interval(TimeSpan.FromMinutes(2)));
			// Reset the subscription to go off in 2 minutes from now
	        // Do other things
	    }
	}
