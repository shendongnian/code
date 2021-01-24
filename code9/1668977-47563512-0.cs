	public class ModuleConfig
    {
		IpAddress { get; set; } = "The IP",
		Port { get; set; } = "The Module Port",
		Buffer { get; set; } = "1024",
		public Dictionary<string, string> ConnectionStrings { get; set; }
        public Redis RedisConfig { get; set } 
    }
