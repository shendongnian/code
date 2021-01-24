	internal class DataModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			//When you specify InstancePerRequest it means that everything (resolved via this DI) 
			//is using the same DataContext for current request
			builder.RegisterType<MyContext>().As<MyContext>().InstancePerRequest();
		}
	}
