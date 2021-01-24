	public class MyService : ServiceBase
	{
		public void DoTheServiceLogic()
		{
			// Does its thing
		}
		
		public override void OnStart(...)
		{
			DoTheServiceLogic();
		}
	}
