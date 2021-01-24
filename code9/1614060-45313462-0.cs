    public static class NLogHelper
    {
        public static void StampedInfo(this NLog.Logger logger, string message)
        {
            var eventInfo = new LogEventInfo(LogLevel.Info, logger.Name, message);
            eventInfo.Properties["mytimestamp"] = Time.ConvertUtcToEst(DateTime.UtcNow);
            logger.Log(eventInfo);
        }
    }
    // usage:
    //   var log = LogManager.GetLogger(loggerName);
    //   log.StampedInfo("message");
