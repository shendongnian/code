	public interface IMyService
	{
		void MyMethod();
	}
	internal class MyImplementation : IMyService
	{
		#region IMyService
		public void MyMethod()
		{
			// do something useful ModuleA's way
		}
		#endregion
	}
	internal class ModuleA : IModule
	{
		public ModuleA( IUnityContainer container )
		{
			_container = container;
		}
		#region IModule
		public void Initialize()
		{
			_container.RegisterType<IMyService, MyImplementation>();
		}
		#endregion
		#region private
		private readonly IUnityContainer _container;
		#endregion
	}
	internal class SomeClass
	{
		public SomeClass( IMyService myService )
		{
			_myService = myService;
		}
		public void SomeMethod()
		{
			// use ModuleA's method here:
			_myService.MyMethod();
		}
		#region private
		private readonly IMyService _myService;
		#endregion
	}
