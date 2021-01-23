	public interface IFooDependency
	{
	}
	internal class FooDependency : IFooDependency
	{
	}
	public class FooController
	{
		public FooController(IFooDependency dependency)
		{
			// ...
		}
	}
