      public class JobSchedulerClass : IJob
      {
        public void Execute(IJobExecutionContext context)
        {
          Common obj = new Common();
          obj.ScheduledPageLoadFunction();
        }
      }
