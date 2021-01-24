    class Program
    {
        static void Main(string[] args)
        {
           var kernel = new StandardKernel();
           var server = WebApp.Start("http://localhost:8080/", (appBuilder) =>
           {
               var resolver = new NinjectSignalRDependencyResolver(kernel);
               var config = new HubConfiguration {Resolver = resolver};
               ...
           });
           
           ...
