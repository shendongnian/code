	public class SomeClass : IDisposable
	{
		private readonly StreamReader _reader; //a disposable class
		private bool shouldDispose;
	
		public SomeClass(StreamReader reader) : this(reader, true)
		{
		}
		
		public SomeClass(StreamReader reader, bool shouldDispose)
		{
			_reader = reader;
			this.shouldDispose = shouldDispose;
		}
		
		public void Dispose()
		{
			if (shouldDispose)
			{
				Dispose(true);
			}
		}
		
		protected void Dispose(bool isDisposing)
		{
			if (isDisposing)
			{
				_reader.Dispose();
			}
		}
	}
