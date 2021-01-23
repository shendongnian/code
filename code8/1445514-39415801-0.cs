    namespace ConsoleApplication4
    {
        class Program
        {
            static void Main(string[] args)
            {
                for (int i = 1; i <= 100; i++)
                {
                    if (i < 10)
                    {
                        Console.Write(i.ToString("00 "));
                    }
                    else
                    {
                        Console.Write(i + " ");
                    }
                    if (i % 5 == 0) 
                    {
                        Console.WriteLine();
                    }
                }
                Console.ReadKey();
            }
        }
    }
