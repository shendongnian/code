    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(ClientConnectionService)))
            {
                host.Open();
                Console.WriteLine($"{host.Description.Name} is up and listening on the URI given below. Press <enter> to exit.");
                PrintServiceInfo(host.Description);
                Console.ReadLine();
            }
        }
    
        private static void PrintServiceInfo(ServiceDescription desc)
        {
            foreach (ServiceEndpoint nextEndpoint in desc.Endpoints)
            {
                Console.WriteLine(nextEndpoint.Address);
            }
    
        }
    }
