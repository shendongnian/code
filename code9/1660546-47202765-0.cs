    public static void Main(string[] args)
    {
    	var host = BuildWebHost(args);
    	using (var scope = host.Services.CreateScope())
    	{
    		var services = scope.ServiceProvider;
    		
    		var logger = services.GetRequiredService<ILogger<Program>>();
    		
    		//Do some logging
    	}
    
    	host.Run();
    }
