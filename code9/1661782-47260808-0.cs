    class Program
    {
    
	    static void Main()
	    {
		    var container = new UnityContainer();
		
			//the instance to be injected
		    var systemClient = new JobSystemClient
		    {
			    UserName = "admin",
			    PassWord = "admin1234"
		    };
	
		    container.RegisterInstance<ISystemClient>(systemClient);
			
			//Registration of the Functions class
		    container.RegisterType<Functions>();			
			
		    var activator = new UnityJobActivator(container);
		    
		    var config = new JobHostConfiguration();
		    config.JobActivator = activator;		    
		    
		    var host = new JobHost(config);
		    // The following code will invoke a function called ManualTrigger and 
		    // pass in data (value in this case) to the function
		    host.Call(typeof(Functions).GetMethod("ManualTrigger"), new { value = 20 });
			host.RunAndBlock();
		    	    
	    }
    }
