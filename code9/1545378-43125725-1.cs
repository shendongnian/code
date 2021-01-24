        public static void Main(string[] args)
        {
            using (var db = new MyDbContext())
            {
                var WorkOrders = db.WorkOrders.ToList();
            }
                var host = new WebHostBuilder()
                    .UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration()
                    .UseStartup<Startup>()
                    .Build();
            host.Run();
        }
