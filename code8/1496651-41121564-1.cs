    protected void Application_Start()
    {
        JobManager.JobFactory = new StructureMapJobFactory();
        JobManager.Initialize(new MyRegistry()); 
    }
    
