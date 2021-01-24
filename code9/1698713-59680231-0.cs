            // Clean up Servers List
            Hangfire.Storage.IMonitoringApi monitoringApi = JobStorage.Current.GetMonitoringApi();
            JobStorage.Current.GetConnection().RemoveTimedOutServers(new TimeSpan(0, 0, 15));
            app.UseHangfireServer(new BackgroundJobServerOptions
            {
                WorkerCount = 1,
                Queues = new[] { "jobqueue" },
                ServerName = "HangfireJobServer",
            });
            RecurringJob.AddOrUpdate("ProcessJob", () => YourMethod(), AppSettings.JobCron, TimeZoneInfo.Local, "jobqueue");
