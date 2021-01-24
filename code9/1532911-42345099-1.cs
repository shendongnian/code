    void Main()
    {
    	using(var clock = new Clock())
    	{
    		clock.Tick += dt => Console.WriteLine(dt);
    		Thread.Sleep(20000);
    	
    	}
    	
    }
    //sealed so we don't need to bother with full IDisposable pattern
    public sealed class Clock:IDisposable
    {
    	public event Action<DateTime> Tick;
    	private CancellationTokenSource tokenSource;
    	public Clock()
    	{
    		tokenSource = new CancellationTokenSource();
    		Loop();
    	}
    	private async void Loop()
    	{
    		while(!tokenSource.IsCancellationRequested)
    		{
    			var now = DateTime.UtcNow;
    			var nowMs = now.Millisecond;
    			var timeToNextSecInMs = 1000 - nowMs;
    			try
    			{
    				await Task.Delay(timeToNextSecInMs, tokenSource.Token);
    			
    			}
    			catch(TaskCanceledException)
    			{
    				break;
    			}
    			var tick = Tick;
    			if(tick != null)
    			{
    				tick(DateTime.UtcNow);
    			}
    		}
    
    	}
    	public void Dispose()
    	{
    		tokenSource.Cancel();
    	}
    }
