    protected void Application_Start(object sender, EventArgs e)
    {
    	if (!ServiceController.isCachingEnabled)
    	{
    		SqlDependency.Stop(strConnectionString);
    		SqlDependency.Start(strConnectionString);
    	}
    }
