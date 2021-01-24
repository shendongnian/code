	public interface ILogFactory
	{
		ILogger GetLogger(string name);
		ILogger GetLogger<TCallingType>(); // Maybe you won't actually need this overload...
		
		ILogger GetLogger(Type type);
	}
