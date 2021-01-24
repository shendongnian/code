    public class BusSettings 
    {
        private readonly IConfiguration _configuration;
        public BusSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Uri HostAddress => new Uri(_configuration["AppSettings:HostAddress"]);
    }
