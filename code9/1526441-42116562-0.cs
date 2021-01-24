        public interface ILogger<T> where T: class
        {
           void Log(string message, LogLevel level);
        }
        public class Logger<T> : ILogger<T>
           where T: class
        {
           public void Log(string message, LogLevel level) 
           {
                WriteLog(typeof(T).Name + ": " + message, level);
           }
        }
