	public class Car
	{
		private IEngine _engine;
		
		public Car(IEngine engine)
		{
			_engine = engine;
		}
		
		public IEngine GetEngine()
		{
			return _engine;
		}
	}
