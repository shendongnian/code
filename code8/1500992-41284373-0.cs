	void Main()
	{
		var executor = new MyExecutor();
		executor.Execute(()=>Console.WriteLine("Hello"));
		executor.Execute(()=>Console.WriteLine(","));
		executor.Execute(()=>Console.WriteLine("World"));
	}
	
	public class MyExecutor
	{
		private Task _current = Task.FromResult(0);
		
		public void Execute(Action action)
		{
			_current=_current.ContinueWith(prev=>action());
		}
	}
