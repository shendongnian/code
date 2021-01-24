    void Main()
    {
    	Connect(new Uri("https://stackoverflow.com/")).Subscribe(x => Console.WriteLine(x.Substring(0, 24)));
    }
    
    public IObservable<string> Connect(Uri uri)
    {
    	return
    		Observable
    			.Create<string>(async o =>
    			{
    				var webClient = new WebClient();
    
    				webClient.UseDefaultCredentials = true;
    
    				var subscription =
    					Observable
    						.Using(
    							() => new CompositeDisposable(webClient, Disposable.Create(() => Console.WriteLine("Disposed!"))),
    							_ =>
    								Observable
    									.FromEventPattern<DownloadStringCompletedEventHandler, DownloadStringCompletedEventArgs>(
    										h => webClient.DownloadStringCompleted += h, h => webClient.DownloadStringCompleted -= h)
    									.Take(1))
    					.Select(x => x.EventArgs.Result)
    					.Subscribe(o);
    
    				await webClient.DownloadStringTaskAsync(uri);
    
    				return subscription;
    			});
    }
