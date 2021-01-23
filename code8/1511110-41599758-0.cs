	using System;
	using Autofac;
						
	public class Program
	{
		public static void Main()
		{
            // Start configuring DI
			IoCConfig.Start();
			
            // Start "scope" in which Autofac builds objects "in"
			using(var scope = IoCConfig.Container.BeginLifetimeScope())
			{
				// Resolve the Worker
                // Autofac takes care of the constructing of the object
                // and it's required parameters
				var worker = scope.Resolve<Worker>();
				
				worker.DoWork();
			}
		}
	}
	
    // the class that does work, it needs the Configuration information
    // so it is added to the constructor parameters
	public class Worker
	{
		private readonly string _connectionString;
		
		public Worker(IConfiguration config)
		{
			_connectionString = config.ConnectionString;
		}
		
		public void DoWork()
		{
			// Connect to DB and do stuff
			Console.WriteLine(_connectionString);
		}
	}
	
	public static class IoCConfig
	{
		public static IContainer Container { get; private set; }
		
		public static void Start()
		{
			var builder = new ContainerBuilder();
			
			
			// Register Global Configuration
			builder.Register(c => new Configuration{
				ConnectionString = "my connection string" // or ConfigurationManager.ConnnectionString["MyDb"].ConnectionString;
			})
				.As<IConfiguration>();
			
            // Register an concrete type for autofac to instantiate
			builder.RegisterType<Worker>();
			
			Container = builder.Build();
		}
		
		private class Configuration : IConfiguration
		{
			public string ConnectionString { get; set; }
		}
		
	}
	
	public interface IConfiguration
	{
		string ConnectionString { get; }
	}
