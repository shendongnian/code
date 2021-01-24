    public class Function
    {
        public string FunctionHandler(string input, ILambdaContext context)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            // create service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();
            // entry to run app.
            return serviceProvider.GetService<App>().Run(input);
        }
        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // add dependencies here
            // here is where you're adding the actual application logic to the collection
            serviceCollection.AddTransient<App>();
        }
    }
    
    public class App
    {
        // if you put a constructor here with arguments that are wired up in your services collection, they will be injected.
        public string Run(string input)
        {
            return "This is a test";
        }
    }
