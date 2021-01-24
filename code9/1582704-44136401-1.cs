	protected void Application_Start()
	{
		// ...
		
		GlobalConfiguration.Configuration.Services.Replace(
			typeof(IHttpControllerActivator),
			new CustomControllerActivator());
	}
