    public class StopwatchWrapper : IDisposable
    {
    	private bool disposed = false;
    	private Stopwatch _overallStopwatch;
    	private List<long> _increments;
    
    	public StopwatchWrapper()
    	{
    		_overallStopwatch = Stopwatch.StartNew();
    		_increments = new List<long>();
    	}
    
    	public void Reset()
    	{
    		_increments.Clear();
    		_overallStopwatch.Restart();
    	}
    
    	public long ElapsedMilliseconds
    	{
    		get
    		{
    			_overallStopwatch.Stop();
    			var elapsed = _overallStopwatch.ElapsedMilliseconds;
    			_increments.Add(elapsed);
                _overallStopwatch.Start();
    
    			return elapsed;
    		}
    	}
    
    	public long OverallMilliseconds
    	{
    		get
    		{
    			return _increments.Sum();
    		}
    	}
    
    	protected virtual void Dispose(bool disposing)
    	{
    		if (!disposed)
    		{
    			if (disposing)
    			{
    				if (_overallStopwatch != null)
    				{
    					_overallStopwatch.Stop();
    				}
    			}
    
    			disposed = true;
    		}
    	}
    
    	public void Dispose()
    	{
    		Dispose(true);
    	}
    }
