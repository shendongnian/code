    public class Program
    {
        public static void Main(String[] args)
        {
            Program.BuildWebHost(args).Run();
        }
        public static IWebHost BuildWebHost(String[] args) =>
            WebHost.CreateDefaultBuilder(args)
				   .UseKestrel()
				   .UseUrls("http://*:8000")
                   .UseStartup<Startup>()
                   .Build();
    }
    public class Statup
    {
        public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}
		public IConfiguration Configuration { get; }
        ........
    }
