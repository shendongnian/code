    class MyJob
    {
        public DateTime ExecuteTime {get;set;}
        public Action Action {get;set;}
    }
    List<MyJob> Jobs = new List<MyJob>();
    public void Timer_Tick(object sender, EventArgs e)
    {
        foreach(var job in Jobs)
        {
            if(job.ExecuteTime < DateTime.Now)
            {
                job.Action();                
                job.ExecuteTime = job.ExecuteTime.Add(TimeSpan.FromDays(1));
            }
        }
    }
