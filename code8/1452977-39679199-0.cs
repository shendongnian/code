	public class CustomExceptionHandler : Java.Lang.Object, Thread.IUncaughtExceptionHandler
	{
		public CustomExceptionHandler(Thread.IUncaughtExceptionHandler exceptionHandler)
		{
			Handle = exceptionHandler.Handle;
		}
		public void UncaughtException(Thread t, Throwable e)
		{
			// Submit exception details to a server
			...
			// Display error message for local debugging purposes
			Debug.WriteLine(e);
		}
	}
