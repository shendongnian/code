    public class MyController
    {
        private readonly IConfiguration _configuration;
        public MyController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
