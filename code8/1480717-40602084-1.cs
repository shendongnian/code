    internal class DataProvider
    {
    	private readonly Subject<string> _dataChangeSubject = new System.Reactive.Subjects.Subject<string>();
    	private IObservable<string> _dataChangeObservable;
    
    	public IObservable<string> ObserveDataChange()
    	{
    		return _dataChangeObservable ?? 
    			(_dataChangeObservable = _dataChangeSubject.Finally(() => { /* Do cleanup here */ }).Publish().RefCount());
    	}
    }
