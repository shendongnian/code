    public class Logger<T> : ILogger<T>
    {
		public Logger(ILoggerFactory factory)
		{
			if (factory == null)
			{
				throw new ArgumentNullException(nameof(factory));
			}
			_logger = factory.CreateLogger(TypeNameHelper.GetTypeDisplayName(typeof(T)));
		}
		
		//	...
	}
