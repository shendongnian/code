    class MyJob
    {
        public DateTime ExecuteTime { get; set; }
        public Action Action { get; set; }
    }
    List<MyJob> Jobs = new List<MyJob>();
    public void Timer_Tick(object sender, EventArgs e)
    {
        foreach (var job in Jobs)
        {
            if (job.ExecuteTime <= DateTime.Now)
            {
                try
                {
                    job.Action();
                }
                catch(Exception exception)
                {
                    // log the exception..
                }
                finally
                {
                    job.ExecuteTime = job.ExecuteTime.Add(TimeSpan.FromDays(1));
                }
            }
        }
    }
    // this AddJob checks if the first execute should be today or tomorrow
    public void AddJob(TimeSpan executeOn, Action action)
    {
        var now = DateTime.Now;
        var firstExec = new DateTime(now.Year, now.Month, now.Day, 4, 0, 0);
        if (firstExec < now)  // time for today is already passed, next day..
            firstExec = firstExec.Add(TimeSpan.FromDays(1));
        Jobs.Add(new MyJob { ExecuteTime = firstExec, Action = action });
    }
    public void Add()
    {
        // Add the jobs.
        AddJob(new TimeSpan(4, 0, 0), RunMyJob);
        AddJob(new TimeSpan(5, 0, 0), RunMyJob2);
    }
    public void RunMyJob()
    {
        // delete or move, whatever...
    }
    public void RunMyJob2()
    {
        // delete or move, whatever...
    }
