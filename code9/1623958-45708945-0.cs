	public class Car
	{
		private Engine _engine;
		
		public Car(Engine engine)
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
