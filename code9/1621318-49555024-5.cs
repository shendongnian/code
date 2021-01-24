    public class MyContainer
    {
    	public static IContainer Container { get; set; }
    
        public static void ConfigureDependencies()
        {
            var builder = new ContainerBuilder();
        
            // Jobs
            builder.RegisterType<MyJob>().As<MyJob>();
    		
    		// DB Contexts
    		
    		// Others
    		
    		Container = builder.Build();
    	}
    	
    	
    	public static IJob GetJobInstance<T>() where T : IJob
        {
            return Container.Resolve<T>();
        }
    }
