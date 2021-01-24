    public class Startup
    {
       public void ConfigureServices(IServiceCollection services)
       {
          ...
          services.AddMvc();
          ...
       }
    
       public void ConfigureContainer(ContainerBuilder builder)
       {
          builder.RegisterType<FunctionExtender>().As<IFunctionsExtender>();
       }
    }
    
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }
    
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services => services.AddAutofac()) <======
                .UseStartup<Startup>()
                .Build();
    }
