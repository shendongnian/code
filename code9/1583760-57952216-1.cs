    using Microsoft.Extensions.Options;
    public class MyController
        {
            readonly IConfiguration _configuration;
            public MyController(IOptions<MyOptions> options)
            {
                _configuration = options.Value.Configuration;
            }
    
            public void Test()
            {
                Console.Log(_configuration["Section:Value"]);
            }
        }
