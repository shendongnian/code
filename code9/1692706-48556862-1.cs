    public void Application_BeginRequest()
    {
        foreach (var task in DependencyResolver.Current.GetServices<IRunOnEachRequest>())
        {
            task.Execute();
        }
    }
	
