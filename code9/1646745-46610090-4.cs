    using System;
    using NLog.Common;
    /// <summary>
    /// Limits the number of messages written per timespan to the wrapped target.
    /// </summary>
    [Target("ParseJsonWrapper", IsWrapper = true)]
    public class ParseJsonWrapper : WrapperTargetBase
    {
        protected override void Write(AsyncLogEventInfo logEvent)
        {
            var json = logEvent.LogEvent.Message;
            // parse json
            // update log event
            logEvent.LogEvent.Exception = new Exception("something");
            // write to wrapped target
            WrappedTarget.WriteAsyncLogEvent(logEvent)
        }
    }
