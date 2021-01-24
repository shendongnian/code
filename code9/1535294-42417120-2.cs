	public class MyClass : IDisposable
	{
		private SomeDisposableObject _disposableObject;
		
		//Some code
		
		public void Dispose()
		{
			if (_disposableObject != null)
			{
				_disposableObject.Dispose();
				_disposableObject = null;
			}
		}
	}
