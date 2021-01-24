    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8085/hello");
            // Create the ServiceHost.
            using (ServiceHost host = new ServiceHost(typeof(MyService), baseAddress))
            {
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                host.Description.Behaviors.Add(smb);
                host.Open();
                Console.WriteLine("The service is ready at {0}", baseAddress);
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();
                // Close the ServiceHost.
                host.Close();
            }
        }
    }
