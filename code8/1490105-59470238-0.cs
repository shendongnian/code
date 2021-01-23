    public void ConfigureServices(IServiceCollection services)
    	{
    		services.AddRazorPages();
    		// To register interface with its concrite type
    		services.AddSingleton<IEmployee, EmployeesMockup>();
    	}
