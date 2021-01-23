	void Main()
	{
	
		Func<SomeAttachment, IObservable<object>> save = sa =>
			Observable.Create<object>(o =>
			{
				var ob =
					Observable
						.FromEventPattern<object>(
							eh => sa.UploadCompleted += eh,
							eh => sa.UploadCompleted -= eh)
						.Take(1)
						.Select(x => x.EventArgs);
				var subscription = ob.Subscribe(o);
				sa.Save();
				return subscription;
			});
			
	    var list = Enumerable.Range(0, 10).Select(i => new SomeAttachment(i)).ToList();
			
	    list
			.ToObservable()
	        .SelectMany(o => save(o))
	        .ToArray()
	        .Subscribe(_ => Console.WriteLine("All Complete. Handling logic goes here."));
	}
	
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
	        //await Task.Delay(TimeSpan.FromMilliseconds(random.Next(1000, 3000)));
	        UploadCompleted?.Invoke(this, new object());
	    }
	
	    public event EventHandler<object> UploadCompleted;
	}
