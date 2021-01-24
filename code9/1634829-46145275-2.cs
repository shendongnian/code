    internal class DataAccessModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<UnitOfWork>().As<UnitOfWork>().InstancePerRequest();
			builder.RegisterType<ClientRepository>().As<ClientRepository>().InstancePerRequest();
			//if you are using generic repository you can register all them in one line like this: 
			//builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerRequest();
		}
    }
