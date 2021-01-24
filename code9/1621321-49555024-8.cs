    public void Start()
    {
        // Configure Dependency Injection
    	MyContainer.ConfigureDependencies();
        
    	JobManager.UseUtcTime();
		JobManager.Start();
		var myJob = MyContainer.GetJobInstance<MyJob>();
		
		Action<Schedule> schedule = s => s.ToRunEvery(1).Hours().At(0);
		
		JobManager.AddJob(myJob, schedule);
    }
