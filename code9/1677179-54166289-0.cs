	public class Function
	{
		private static ServiceProvider ServiceProvider { get; set; }
	 
		/// <summary>
		/// The parameterless constructor is what Lambda uses to construct your instance the first time.
		/// It will only ever be called once for the lifetime of the container that it's running on.
		/// We want to build our ServiceProvider once, and then use the same provider in all subsequent 
		/// Lambda invocations. This makes things like using local MemoryCache techniques viable (Just 
		/// remember that you can never count on a locally cached item to be there!)
		/// </summary>
		public Function()
		{
			var services = new ServiceCollection();
			ConfigureServices(services);
			ServiceProvider = services.BuildServiceProvider();
		}
		
		public async Task FunctionHandler(SQSEvent evnt, ILambdaContext context)
		{
			await ServiceProvider.GetService<App>().Run(evnt);
		}
		/// <summary>
		/// Configure whatever dependency injection you like here
		/// </summary>
		/// <param name="services"></param>
		private static void ConfigureServices(IServiceCollection services)
		{
			// add dependencies here ex: Logging, IMemoryCache, Interface mapping to concrete class, etc...
			// add a hook to your class that will actually do the application logic
			services.AddTransient<App>();
		}
		/// <summary>
		/// Since we don't want to dispose of the ServiceProvider in the FunctionHandler, we will
		/// at least try to clean up after ourselves in the destructor for the class.
		/// </summary>
		~Function()
		{
			ServiceProvider.Dispose();
		}
	}
	public class App
	{
		public async Task Run(SQSEvent evnt)
		{
			// actual business logic goes here
			await Task.CompletedTask;
		}
	}
