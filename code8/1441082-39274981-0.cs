	public class SomeClass : IDisposable
	{
		private readonly StreamReader _reader; //a disposable class
	
		public SomeClass(StreamReader reader) : this(reader, true)
		{
		}
		
		public SomeClass(StreamReader reader, bool shouldDispose)
		{
			_reader = reader;
		}
		
		public void Dispose()
		{
			Dispose(true);
		}
		
		protected void Dispose(bool isDisposing)
		{
			if (isDisposing)
			{
				_reader.Dispose();
			}
		}
	}
