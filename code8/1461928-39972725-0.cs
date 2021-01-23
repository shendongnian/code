    static class Program
    {
        private static MyLogger logger = new MyLogger();
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledException;
            ...
        }
        static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			var exc = e.ExceptionObject as Exception;
			if (exc != null)
            {   // log the exception
				logger.LogException(exc);
            }
            // Problem is logged, Can't continue, so quit the application:
			Environment.Exit(-1);
		}
