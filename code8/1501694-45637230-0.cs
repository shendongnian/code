    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var args = Environment.GetCommandLineArgs().Skip(1).ToArray();
            var builder = new ConfigurationBuilder();
            builder.AddCommandLine(args);
    
            Configuration = builder.Build();
        }
    }
