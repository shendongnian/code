		public static class DependencyContainer
		{
			internal static IContainer Container;
			public static IContainer CreateContainer(Assembly assembly)
			{
				var builder = new ContainerBuilder();
				builder.RegisterControllers(assembly);
				IModule[] modules =
				{
					//You don't have to create lots of modules...
					//but it would be better to have different modules for different application layers
					new DataModule( /*some params if you need*/),
					new DataAccessModule( ),
					//new BusinessLogicModule(),
					//...
				};
				foreach (var module in modules)
				{
					builder.RegisterModule(module);
				}
				return Container;
			}        
		}
