    public class ValueSource<T>
	{
		private Func<T> _acessor;
		public ValueSource(Func<T> acessor)
		{
			_acessor = acessor;
		}
	
		public T Value
		{
			get 
			{ 
				try 
				{
					return _acessor();
				}
				catch
				{
					return default(T);
				}
			}
		}
	}
