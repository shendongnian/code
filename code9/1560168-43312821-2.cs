    private static string GetUserEmail2(UserCredential credential)
    {
    	// Create Drive API service.
    	var service = new DriveService(new BaseClientService.Initializer()
    	{
    		HttpClientInitializer = credential,
    		ApplicationName = "Name-Of-Your-Google-App",
    	});
    
    	var about = service.About.Get().Execute();
    
    	return about.User.EmailAddress;
    }
