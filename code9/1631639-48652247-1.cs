    public class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("AppSettings.json");
            var config = builder.Build();
   
            var appConfig = config.GetSection("Settings").Get<AppSettings>();
    
            Console.WriteLine(appConfig.ExampleString);
            Console.WriteLine(appConfig.Number);
        }
    }
    
    public class AppSettings
    {
        public string ExampleString { get; set; }
        public int Number { get; set; }
    }
