    public class Bindings : NinjectModule
	{
		public override void Load()
		{
			Bind<RegisterUserCommand>().To<RegisterUserCommand>().WithConstructorArgument( new UserService());
			Bind<LoginCommand>().To<LoginCommand>().WithConstructorArgument( new UserService());
			Bind<CreateEventCommand>().To<CreateEventCommand>().WithConstructorArgument(  new EventService());
			//and another models
		}
	}
