    public class Bindings : NinjectModule
	{
		public override void Load()
		{
			//init parameters
			Bind<UserService>().To<UserService>();
			Bind<EventService>().To<EventService>();
		}
	}
