    public class MyClass
    {
        private readonly ILogger _logger;
        public MyClass(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<MyClass>();
            "Test".ToSomething(_logger);
        }
         public static string ToSomething(this string source, ILogger logger)
         {
            logger.LogInformation(source);
            return source;    
         }
    }
    
