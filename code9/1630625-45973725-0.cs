	public interface IMyInterface
	{ }
	public interface IMyInterface<T>
	{
		T getVal();
	}
	public class MyInterfaceDouble : IMyInterface<double>, IMyInterface
	{
		public double getVal()
		{
			return 8.355;
		}
	}
	
    public class MyGeneric<T> where T : IMyInterface
    {
        T Obj { get; }
    }
