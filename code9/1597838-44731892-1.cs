    public class YourClass
    {
        IConfigurationRoot _config;
        public YourClass(IConfigurationRoot config)
        {
            _config = config;
        }
        public void SomeMethod()
        {
            var connStr = _config["ConnectionStrings:DefaultConnection"];
        }
    }
