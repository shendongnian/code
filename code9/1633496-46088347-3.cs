    //add this using statement and corresponding package
    //"Microsoft.Extensions.Options.ConfigurationExtensions": "1.1.1"
    using Microsoft.Extensions.Options;
    
    public class MyClass
    {
        private MyConfiguration _configuration;
        
        
        public MyClass(IOptions<MyConfiguration> configuration)
        {
            _configuraiton = configuraiton.Value;
        }
    }
