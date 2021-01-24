    namespace ConsoleApplication1
    {
        class Program
        {
            public static void Main()
            {
                Uri uriAddress1 = new Uri("C:\\Users\\Documents\\MyWeb\\Slide\\Main\\slider2.png");
                Console.WriteLine("The parts are {0}{1}{2}", uriAddress1.Segments[5], uriAddress1.Segments[6], uriAddress1.Segments[7]);
                Console.ReadKey();
            }
        }
    }
