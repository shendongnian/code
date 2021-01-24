     public static void Main(string[] args)
        {
            var host = new WebHostBuilder().UseKestrel()
               // .UseContentRoot(Directory.GetCurrentDirectory()) //<== The mistake
                .UseIISIntegration()
                .UseStartup<Program>()
                .Build();
            host.Run();
        }
