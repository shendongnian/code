	public IObservable<info> infos()
	{
		return
			from n in Observable.Range(0, 100)
			from i in Observable.FromAsync(() => ApiRequestInfo(n))
			select i;
	}
	
	public Task<info> ApiRequestInfo(int index)
	{
		// implement your actual API call here.
		return Task.Factory.StartNew(() => new info() { Index = index });
	}
	
	public class info
	{
		public int Index;
	}
