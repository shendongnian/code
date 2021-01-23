    // Defines a logger for managing system logging output  
    public interface ILog
    {
        // Logs an error message to the logs
        void LogError(string message);
    
        // Logs a debug message to the logs
        void LogDebug(string message);
    }
    
    public static void ChangeLogging()
    {
        DefaultLogger.SetLog(new MyOwnLogger());
    }
    
    class MyOwnLogger : ILog
    {
        public void LogError(string message)
        {
            Console.WriteLine("ERROR!!!: " + message);
        }
    
        public void LogDebug(string message)
        {
            // Dont want to log debug messages
        }
    }
