    class Program {
        static void Main(string[] args) {
            var baseAddress = "http://localhost:8080";
            var config = new HttpSelfHostConfiguration(baseAddress);
            config.MapHttpAttributeRoutes();//map attribute routes
            // Create the server
            using (var server = new HttpSelfHostServer(config)) {
                server.OpenAsync().Wait();
                Console.WriteLine("The service is ready at {0}", baseAddress);
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();
            }
        }
    }
