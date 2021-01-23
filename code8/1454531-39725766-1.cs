	try
	{
		return System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;
	}
	catch(Exception ex)
	{
		return Assembly.GetExecutingAssembly().GetName().Version;
	}
