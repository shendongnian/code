    public class Program
    {
        private readonly ILogger<Program> logger;
        public Program()
        {
            logger = services.GetService<ILoggerFactory>()
                .AddLog4Net()
                .CreateLogger<Program>();
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
        }
        private void Run()
        {
            logger.LogInformation("Logging is working");
        }
    }
