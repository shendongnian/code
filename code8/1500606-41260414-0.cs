    namespace ConsoleApplication1
    {
        class Program
        {
            public static void Main()
            {
                Directory.CreateDirectory("Test");
                Console.WriteLine($"Absolute path is: { Path.GetFullPath("Test")}");
                Console.ReadLine();
            }
        }
     }
