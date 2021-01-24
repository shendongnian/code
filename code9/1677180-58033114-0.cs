    public class Function
    {
        private ServiceCollection _serviceCollection;
    
        public Function()
        {
            ConfigureServices();
        }
    
        public string FunctionHandler(string input, ILambdaContext context)
        {
            using (ServiceProvider serviceProvider = _serviceCollection.BuildServiceProvider())
            {
                // entry to run app.
                return serviceProvider.GetService<App>().Run(input);
            }
        }
    
        private void ConfigureServices()
        {
            // add dependencies here
            _serviceCollection = new ServiceCollection();
            _serviceCollection.AddTransient<App>();
        }
    }
