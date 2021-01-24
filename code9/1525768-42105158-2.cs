    using System;
    using DotNetNuke.Services.Scheduling;
    namespace A
    {
        public class B : SchedulerClient
        {
            public B(ScheduleHistoryItem scheduleHistoryItem)
            {
                base.ScheduleHistoryItem = scheduleHistoryItem;
            }
            public override void DoWork()
            {
                try
                {
                    this.MyMethod();
                    base.ScheduleHistoryItem.Succeeded = true;
                }
                catch (Exception ex)
                {
                    base.ScheduleHistoryItem.Succeeded = false;
                    base.ScheduleHistoryItem.AddLogNote("Oops!! something went wrong!");
                    base.Errored(ref ex);
                }
            }
            public void MyMethod()
            {
                // your logic here ...
                // this codes will be run by DNN
                System.IO.File.AppendAllText(HttpContext.Current.Server.MapP‌​ath("/SchedulerLog.t‌​xt"), "Scheduler fired! at " + DateTime.Now.ToString());
            }
        }
    }
