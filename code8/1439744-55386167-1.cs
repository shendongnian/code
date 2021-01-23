    public class MyClass 
    {
        private IConfiguration configuration;
        public MyClass(IConfiguration configuration)
        {
            ConnectionString = new configuration.GetValue<string>("ConnectionString");
        }
 
