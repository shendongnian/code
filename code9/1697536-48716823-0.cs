    public static void Main(string[] args)
    {
    	var host = BuildWebHost(args);
    
    	using (var scope = host.Services.CreateScope())
    	{
    		var services = scope.ServiceProvider;
    		var config = services.GetService<IConfiguration>(); // the key/fix!
    		var s = config.GetValue<string>("SeedDb");
    		var doSeed = bool.Parse(s);	// works!
    	}
    
    	host.Run();
    }
