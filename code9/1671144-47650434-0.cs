    using System;
    using Quartz;
     
    namespace FooBar
    {
        public class LoggingJob : IJob
        {
            public void Execute(IJobExecutionContext context)
            {
     
     
                Common.Logging.LogManager.Adapter.GetLogger("LoggingJob").Info(
                    string.Format("Logging job : {0} {1}, and proceeding to log", 
                        DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString()));
     
            }
        }
    }
    
    
