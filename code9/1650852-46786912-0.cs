    public class LogHelperWrapper : ILogger {
        public void LogDebug(string source, string msg) {
            LogHelper.LogDebug(source, msg);
        }
        //...other members
    }
