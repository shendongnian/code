	internal class Program
	{
		static void Main( string[] args )
		{
			var container = new UnityContainer();
			container.RegisterType<IDependency, MyDependency>((string)null);
			var resolved = container.Resolve<Consumer>();
			// resolved.Dependency is an instance of MyDependency
		}
	}
	internal class Consumer
	{
		[Dependency]
		public IDependency Dependency { get; set; }
	}
	public interface IDependency
	{
	}
	internal class MyDependency : IDependency
	{
	}
