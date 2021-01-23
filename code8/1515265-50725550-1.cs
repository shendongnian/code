        private static string _environmentName;
        public static void Main(string[] args)
        {
            var webHost = BuildWebHost(args);
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.{_environmentName}.json", optional: true, reloadOnChange: true)
                .AddCommandLine(args)
                .Build();
