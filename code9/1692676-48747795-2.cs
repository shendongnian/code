    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<ICalculator> factory = new ChannelFactory<ICalculator>("BasicHttpsBinding_ICalculator");
            factory.Endpoint.EndpointBehaviors.Add(new CustomBehavior());
            var client = factory.CreateChannel();
            var number = client.Add(1, 2);
            Console.WriteLine(number.ToString());
        }
    }
