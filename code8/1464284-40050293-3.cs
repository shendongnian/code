    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press <Enter> to proceed.");
            Console.ReadLine();
            var binding = new BasicHttpBinding();
            var endpoint = new EndpointAddress("http://localhost:8732/Design_Time_Addresses/Service1/");
            var channelFactory = new ChannelFactory<IService1>(binding, endpoint);
            // Create a channel.
            IService1 wcfClient1 = channelFactory.CreateChannel();
            string s = wcfClient1.GetData(42);
            Console.WriteLine(s);
            ((IClientChannel)wcfClient1).Close();
            Console.WriteLine("Press <Enter> to quit the client.");
            Console.ReadLine();
        }
    }
