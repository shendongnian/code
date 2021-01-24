    namespace YourNameSpace
    {
        public class TimeBoundedRollingFileAppender : RollingFileAppender
        {
            public int LogFrom { get; set; }
            public int LogTo { get; set; }
            
            protected override bool FilterEvent(LoggingEvent loggingEvent)
            {
                var currentHour = DateTime.Now.Hour;
                if (currentHour <= LogFrom || currentHour >= LogTo)
                {
                    return false;
                }
    
                return base.FilterEvent(loggingEvent);
            }
        }
    }
