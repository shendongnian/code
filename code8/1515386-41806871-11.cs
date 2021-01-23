    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Service1Client client = new Service1Client();
                ArrayOfDateTime result = client.NullTest();
                foreach (DateTime dt in result)
                    Console.WriteLine(dt);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
