    public void Start()
    {
        // Configure Dependency Injection
    	MyContainer.ConfigureDependencies();
        
    	// Setup the Fluent Scheduler - 
    	JobManager.JobFactory = new MyJobFactory();
        
    	JobManager.UseUtcTime();
        
    	JobManager.Initialize(new MyJobRegistry());		
    }
