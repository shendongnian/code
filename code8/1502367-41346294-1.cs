    // model
    public class AsyncCommunicationObject
	{
		public string Key { get; }
		public string Value { get; }
		public AsyncCommunicationObject(string key, string value)
		{
			Key = key;
			Value = value;
		}
	}
	
    // injectable singleton	
	public static Subject<AsyncCommunicationObject> AsyncCommunication { get; set; } = new Subject<AsyncCommunicationObject>();
		
    // in web service			
	System.Threading.EventWaitHandle waitHandle = new System.Threading.AutoResetEvent(false);
	string yourID = some ID
	var subscription = _asyncCommunication (injected)
		.Where(x => x.Key == yourID)
		.Take(1)
		.Subscribe(
			x =>
			{
				dbId = x.Value;
				waitHandle.Set();
			}
		);
    _schedulerCore.ExecuteJob(upload.JobId, jobDataMap);
	waitHandle.WaitOne();
	waitHandle.Reset();
	subscription.Dispose();
    // in job listener
    _asyncCommunication.OnNext(new AsyncCommunicationObject(your ID, some value)
