    public class Program
        {
            public static void Main(string[] args)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");
    
                var config = builder.Build();
    
                var services = new ServiceCollection().AddOptions();
    
                services.Configure<ApiConfig>(x => config.GetSection("ApiConfig").Bind(x));
                services.Configure<Fruit>(x => config.GetSection("Fruit").Bind(x));
    
                var serviceProvider = services.BuildServiceProvider();
                var apiConfig = serviceProvider.GetService<IOptions<ApiConfig>>().Value;
                var fruit = serviceProvider.GetService<IOptions<Fruit>>().Value;
    
                Console.WriteLine(string.Format("\r\nGoodErrorMappings: {0}", JsonConvert.SerializeObject(apiConfig.GoodErrorMappings, Formatting.Indented)));
                Console.WriteLine(string.Format("\r\nBadErrorMappings: {0}", JsonConvert.SerializeObject(apiConfig.BadErrorMappings, Formatting.Indented)));
                Console.WriteLine(string.Format("\r\nFruit: {0}", JsonConvert.SerializeObject(fruit, Formatting.Indented)));
    
                Console.ReadLine();
            }
        }
    
        public class Fruit : List<string>
        {
        }
    
        public class ApiConfig
        {
            public Dictionary<string, ErrorMapping> GoodErrorMappings { get; set; } = new Dictionary<string, ErrorMapping>();
            public Dictionary<string, ErrorMapping[]> BadErrorMappings { get; set; } = new Dictionary<string, ErrorMapping[]>();
        }
    
        public class ErrorMapping
        {
            public int HttpStatusCode { get; set; }
            public int ErrorCode { get; set; }
            public string Description { get; set; }
        }
