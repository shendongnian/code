    public class DatabaseLogger
	{
		readonly static log4net.ILog logger = log4net.LogManager.GetLogger("ADONetAppender");
		public static void LogDebug(string message)
		{
			logger.Debug(message);
		}
	}
