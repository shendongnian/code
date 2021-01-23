	public class SimpleFactory<T> : IFactory<T>
	{
		private IContainer _container;
		
		public SimpleFactory(IContainer container)
		{
			_container = container;		
		}
		
		public T GetInstance()
		{
			return _container.Resolve<T>();
		}
	}
	
	public class DbContextFactory : SimpleFactory<IADbContext>
	{	
		public DbContextFactory(IContainer container):base(container)
		{	
		}
	}
