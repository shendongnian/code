    public static class StaticLogger
    {
        private static Object theThreadLock = new Object();
        private static TelemetryClient _APM;
        public static TelemetryClient APM
        {
            get
            {
                lock (theThreadLock)
                {
                    if (_APM == null) { _APM = new TelemetryClient(); }
                    return _APM;
                }
            }
        }
        public static void Warning(string message)
        {            
            APM.TrackTrace(message, SeverityLevel.Warning);
        }                
        public static void Error(Exception exception,LoggerEvents logEvent)
        {
            lock (theThreadLock)
            {
                var telemetry = new ExceptionTelemetry(exception);
                APM.TrackEvent(logEvent.ToString());
                APM.TrackException(telemetry);
            }
        }
        public static void Error(Exception exception,LoggerEvents logEvent, string fmt, params object[] vars)
        {
            lock (theThreadLock)
            {
                var telemetry = new ExceptionTelemetry(exception);
                telemetry.Properties.Add("message", string.Format(fmt, vars));
                APM.TrackException(telemetry);
            }
        }
        public static void Trace(string Message, string userID)
        {
            lock(theThreadLock)
            {
                APM.Context.User.Id = userID.ToString();
                Trace(Message);
            }
            
        }
        public static void Trace(string Message)
        {
            lock (theThreadLock)
            {
                APM.TrackTrace(Message);
            }
        }
        public static void TraceAPI(string currentNameSpace,string componentName, string method, string httpAction, TimeSpan timespan)
        {
            TraceAPI(currentNameSpace,componentName, method, httpAction, timespan, string.Empty);
        }
        public static void TraceAPI(string currentNameSpace,string componentName, string method, string httpAction, TimeSpan timespan, string fmt, params object[] vars)
        {
            TraceAPI(currentNameSpace,componentName, method, httpAction, timespan, string.Format(fmt, vars));
        }
        public static void TraceAPI(string currentNameSpace,string componentName, string method, string httpAction, TimeSpan timespan, string properties)
        {
            lock (theThreadLock)
            {
                var telemetry = new TraceTelemetry("Trace API call", SeverityLevel.Information);
                telemetry.Properties.Add("namespace", currentNameSpace);
                telemetry.Properties.Add("component", componentName);
                telemetry.Properties.Add("method", method);
                telemetry.Properties.Add("HttpAction", httpAction);
                telemetry.Properties.Add("timespan", timespan.ToString());
                if (!string.IsNullOrWhiteSpace(properties))
                    telemetry.Properties.Add("properties", properties);
                APM.TrackTrace(telemetry);
            }
        }
        public static void TraceAPI(string currentNameSpace, string componentName, string method, string httpAction, TimeSpan timespan, IDictionary<string, string> properties = null)
        {
            lock (theThreadLock)
            {
                var telemetry = new TraceTelemetry("Trace API call", SeverityLevel.Information);
                telemetry.Properties.Add("namespace", currentNameSpace);
                telemetry.Properties.Add("component", componentName);
                telemetry.Properties.Add("method", method);
                telemetry.Properties.Add("HttpAction", httpAction);
                telemetry.Properties.Add("timespan", timespan.ToString());
                if (properties != null)
                {
                    foreach (var property in properties)
                    {
                        telemetry.Properties.Add(property.Key, property.Value);
                    }
                }
                APM.TrackTrace(telemetry);
            }
        }
        public static void TraceMethod(string currentNameSpace, string componentName, string method, TimeSpan timespan, string properties)
        {
            lock (theThreadLock)
            {
                var telemetry = new TraceTelemetry("Trace API call", SeverityLevel.Information);
                telemetry.Properties.Add("namespace", currentNameSpace);
                telemetry.Properties.Add("component", componentName);
                telemetry.Properties.Add("method", method);                
                telemetry.Properties.Add("timespan", timespan.ToString());
                if (!string.IsNullOrWhiteSpace(properties))
                    telemetry.Properties.Add("properties", properties);
                APM.TrackTrace(telemetry);
            }
        }
        public static void TraceMethod(string currentNameSpace, string componentName, string method, TimeSpan timespan, IDictionary<string, string> properties = null)
        {
            lock (theThreadLock)
            {
                var telemetry = new TraceTelemetry("Trace API call", SeverityLevel.Information);
                telemetry.Properties.Add("namespace", currentNameSpace);
                telemetry.Properties.Add("component", componentName);
                telemetry.Properties.Add("method", method);
                telemetry.Properties.Add("timespan", timespan.ToString());
                if (properties != null)
                {
                    foreach (var property in properties)
                    {
                        telemetry.Properties.Add(property.Key, property.Value);
                    }
                }
                APM.TrackTrace(telemetry);
            }
        }
        public static void TrackEvent(string message)
        {
            lock (theThreadLock)
            {
                APM.TrackEvent(message);
            }
        }
        public static void TrackEvent(string message, IDictionary<string, string> properties)
        {
            lock (theThreadLock)
            {
                var telemetry = new TraceTelemetry("Track Event", SeverityLevel.Information);
                telemetry.Message = message;
                if (properties != null)
                {
                    foreach (var property in properties)
                    {
                        telemetry.Properties.Add(property.Key, property.Value);
                    }
                }
                APM.TrackEvent(message);
            }
        }
    }
    public sealed class LoggerEvents
    {
        private readonly string name;
        private readonly int value;
        public readonly static LoggerEvents ErrorWebSite = new LoggerEvents(1, "Error:WebSite");
        public readonly static LoggerEvents UnhandledException = new LoggerEvents(2, "UnhandledException");
        public readonly static LoggerEvents UserNotActive = new LoggerEvents(3, "UserNotActive");
        public readonly static LoggerEvents InvalidURL = new LoggerEvents(4, "InvalidURL");
        public readonly static LoggerEvents ConsentRefused = new LoggerEvents(5,"ConsentRefused");
        public readonly static LoggerEvents ConsentAccepted = new LoggerEvents(6, "ConsentAccepted");
        public readonly static LoggerEvents UserLoginSuccess = new LoggerEvents(7, "LoginSuccess");
        public readonly static LoggerEvents UserLoginFailure = new LoggerEvents(7, "LoginFailure");
        private LoggerEvents(int value, string name)
        {
            this.name = name;
            this.value = value;
        }
        public override string ToString()
        {
            return name;
        }
    }
