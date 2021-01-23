    class Program
    {
        static void Main(string[] args)
        {
            var baseAddress = new Uri("http://localhost:8732/Design_Time_Addresses/Service1/");
            using (var host = new ServiceHost(typeof(Service1), baseAddress))
            {
                // Enable metadata publishing.
                var smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                host.Description.Behaviors.Add(smb);
                // Open the ServiceHost to start listening for messages. Since no endpoints are
                // explicitly configured, the runtime will create one endpoint per base address
                // for each service contract implemented by the service.
                host.Open();
                Console.WriteLine("The service is ready at {0}", baseAddress);
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();
                
                host.Close();
            }
        }
    }
