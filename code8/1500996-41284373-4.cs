	void Main()
	{
		var executor = new MyExecutor();
		executor.Execute(() => Console.WriteLine("Hello"));
		executor.Execute(() => Thread.Sleep(100));
		executor.Execute(() => Console.WriteLine(","));
		executor.Execute(() => { throw new Exception(); });
		executor.Execute(() => Console.WriteLine("World"));
		executor.Execute(() => Thread.Sleep(100));
	
		executor.WaitCurrent();
	
		Console.WriteLine($"{nameof(MyExecutor.Total)}:{executor.Total}");
		Console.WriteLine($"{nameof(MyExecutor.Finished)}:{executor.Finished}");
		Console.WriteLine($"{nameof(MyExecutor.Failed)}:{executor.Failed}");
	}
	
	public class MyExecutor
	{
		private Task _current = Task.FromResult(0);
		private int _failed = 0;
		private int _finished = 0;
		private int _total = 0;
		private object _locker = new object();
		
		public void WaitCurrent()
		{
			_current.Wait();		
		}
	
		public int Total
		{
			get { return _total; }
		}
	
		public int Finished
		{
			get { return _finished; }
		}
	
		public int Failed
		{
			get { return _failed; }
		}
	
		public void Execute(Action action)
		{
			lock (_locker) // not sure that lock it is the best way here
			{
				_total++;
				_current = _current.ContinueWith(prev => SafeExecute(action));
			}
		}
	
		private void SafeExecute(Action action)
		{
			try
			{				
				action();
			}
			catch 
			{
				Interlocked.Increment(ref _failed);
			}
			finally 
			{
				Interlocked.Increment(ref _finished);
			}
		}
	}
