       private EmailScheduler scheduler;
       public void FormLoad()
       {
           scheduler =  new EmailScheduler();
           scheduler.Start();
       }
       public void FormUnload()
       {
           scheduler.Stop();
           scheduler.Dispose();
       }
