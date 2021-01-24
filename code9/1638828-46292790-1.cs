    public class MyDriver : IDriver<Configuration>
    {
        public Configuration Config { get; set; }
        public string DriverName => Config.DriverName;
    }
