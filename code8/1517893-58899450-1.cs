        public class Global : System.Web.HttpApplication
        {
            void Application_Start(object sender, EventArgs e)
            {
                if (Core.AppConfigSettings.EnableHangFire)
                {
                    JobManager.Instance.Start();
    
                    new SchedulePendingSmsNotifications().Schedule(new Core.JobInfo() { JobId = 0, JobType = typeof(SchedulePendingSmsNotifications), Delay = TimeSpan.FromMinutes(1), IsRecurring = true });
                    
                }
            }
            protected void Application_End(object sender, EventArgs e)
            {
                if (Core.AppConfigSettings.EnableHangFire)
                {
                    JobManager.Instance.Stop();
                }
            }
        }
    
