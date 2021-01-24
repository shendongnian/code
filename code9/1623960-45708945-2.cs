	public class Car
	{
		private IEngine _engine;
		
		public Car(IEngine engine)
		{
			_engine = engine;
		}
		
		public void StartMoving()
		{
            if (_engine is CombustionEngine ce)
           {
			    ce.FireSparkPlugs();
           }
		   else
		   {
				// ...
		   }
		}
	}
