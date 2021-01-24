	public class UploadDicomSet : ImportBaseSet
	{
		IDisposable subscription;
	
		public void CreateSubscription()
		{
			var cachCleanTimer = Observable.Interval(TimeSpan.FromMinutes(2));
			
			if(subscription != null)
				subscription.Dispose();
			
			subscription = cachCleanTimer.Subscribe(s => CheckUploadSetList(s));
		}
	
		public UploadDicomSet()
		{
			CreateSubscription();
			// Do other things
		}
	
		void CheckUploadSetList(long interval)
		{
			subscription.Dispose(); // Stop the subscription
			// Do other things
		}
	
		public void AddDicomFile(SharedLib.DicomFile dicomFile)
		{
			CreateSubscription(); // Reset the subscription to go off in 2 minutes from now
			// Do other things
		}
	}
