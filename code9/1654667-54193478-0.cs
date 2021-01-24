        public static void GetSection()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
            string BConfig = Configuration.GetSection("ConnectionStrings")["BConnection"];
        }
