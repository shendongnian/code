    public void StartJob()
    {
      IScheduler iPageRunCodeScheduler;
      string SCHEDULE_RUN_TIME = "05:00"; // 05:00 AM
      // Grab the Scheduler instance from the Factory 
      iPageRunCodeScheduler = StdSchedulerFactory.GetDefaultScheduler();
      TimeSpan schedularTime = TimeSpan.Parse(SCHEDULE_RUN_TIME);
      iPageRunCodeScheduler.Start();
      DbCls obj = new DbCls();
      // define the job and tie it to our class
      DateTime scheduleStartDate = DateTime.Now.Date.AddDays((DateTime.Now.TimeOfDay > schedularTime) ? 1 : 0).Add(schedularTime);
      //IJobDetail job = JobBuilder.Create<Unity.Web.Areas.Admin.Controllers.CommonController.DeleteExportFolder>()
      IJobDetail job = JobBuilder.Create<JobSchedulerClass>() // JobSchedulerClass need to create this class which implement IJob
          .WithIdentity("job1", "jobGrp1")
          .Build();
      // Trigger the job to run now, and then repeat every 10 seconds
      ITrigger trigger = TriggerBuilder.Create()
          .WithIdentity("trigger1", "jobGrp1")
          //.StartNow()
          .StartAt(scheduleStartDate)
          .WithSimpleSchedule(x => x
              //.WithIntervalInHours(24)
              .WithIntervalInSeconds(15)
              .RepeatForever())
          .Build();
      // Tell quartz to schedule the job using our trigger
      iPageRunCodeScheduler.ScheduleJob(job, trigger);
    }
