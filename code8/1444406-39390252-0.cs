    void Main()
    {
    	var list = Enumerable.Range(0, 10).Select(i => new SomeAttachment(i)).ToList();
    	
    	list.ToObservable()
    		.Do(sa => sa.Save())
    		//.Do(sa => Console.WriteLine($"{sa.Id}: Save called"))
    		.Select(sa => Observable.FromEventPattern<object>(eh => sa.UploadCompleted += eh, eh => sa.UploadCompleted -= eh))
    		.SelectMany(o => o.Take(1))
    		//.Do(o => Console.WriteLine($"{(o.Sender as SomeAttachment).Id}: Upload completed."))
    		.All(_ => true)
    		.Take(1)
    		.Subscribe(_ => Console.WriteLine("All Complete. Handling logic goes here."));
    }
    
    // Define other methods and classes here
    
    public class SomeAttachment
    {
    	private static Random random = new Random();
    	private readonly int _id;
    	public SomeAttachment(int id)
    	{
    		_id = id;
    	}
    	public int Id
    	{
    		get { return _id; }
    	}
    	
    	public async Task Save()
    	{
    		
    		await Task.Delay(TimeSpan.FromMilliseconds(random.Next(1000, 3000)));
    		UploadCompleted?.Invoke(this, new object());
    	}
    	
    	public event EventHandler<object> UploadCompleted;
    	
    }
