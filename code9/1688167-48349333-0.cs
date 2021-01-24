    class Program
    {
        static void Main(string[] args)
        {
            var client = new ServiceReference1.SampleWebServiceSoapClient();
            string result = client.HelloWorld();
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
