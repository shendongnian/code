	internal class Program
	{
		static void Main( string[] args )
		{
			var container = new UnityContainer();
			container.RegisterTypes( AllClasses.FromLoadedAssemblies().Where( type => type.Name.Contains("Handler") ), WithMappings.FromAllInterfaces, WithName.Default, WithLifetime.Transient );
			var instance = container.Resolve<IHandler<TestCommand>>();
			var instance2 = container.Resolve<IHandler<TestCommand2>>();
		}
	}
	public interface IHandler<TCommand>
	{
	}
	public class MyTestHandler : IHandler<TestCommand>
	{
	}
	public class TestCommand
	{
	}
	public class MyTestHandler2 : IHandler<TestCommand2>
	{
	}
	public class TestCommand2
	{
	}
