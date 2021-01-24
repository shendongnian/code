    public class CwiLogger
    {
        private static LoggingConfiguration _logConfig = new LoggingConfiguration();
        private static Object createLogLock = new Object();
        private Logger _log;
        public CwiLogger(string logPath, string logName, string className)
        {
                lock (createLogLock)
                {
                    var fileTarget = _logConfig.FindTargetByName(logName);
                    if (fileTarget == null)
                    {
                        var fileTarget = new FileTarget(logName);
                        fileTarget.FileName = Path.Combine(logPath, logName);
                        fileTarget.Layout = "${longdate}|${level:uppercase=true}|${logger}|${message}";
                        _logConfig.AddTarget(fileTarget);
                        var rule = new LoggingRule(className, LogLevel.Debug, fileTarget) { Final = true };
                        _logConfig.LoggingRules.Add(rule);
                        LogManager.Configuration = _logConfig;
                    }
                }
            this._log = LogManager.GetLogger(className);
        }
        public void AddToLog(string logText, LogLevel level = null)
        {
            level = level ?? LogLevel.Info;
            this._log.Log(level, logText + "\n");
        }
    }
