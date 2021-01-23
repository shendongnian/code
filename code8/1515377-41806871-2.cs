    class Program
    {
        static void Main(string[] args)
        {
            Service1Client client = new Service1Client();
            NullableOfdateTime[] result = client.NullTest();
            foreach (NullableOfdateTime ndt in result)
                Console.WriteLine(ndt.Value);
            Console.ReadLine();
        }
    }
