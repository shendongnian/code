    static void Main(string[] args)
        {
            Process();
        }
        static void Process()
        {
            Console.Write("Enter a number: ");
            int.TryParse(Console.ReadLine(), out int num);
            Print(num);
        }
        static void Print(int num)
        {
            if (num % 2 == 0)
            {
                Console.WriteLine(string.Empty.PadLeft(num, '*'));
            }
            else
            {
                for (int i = 0; i < num; i++)
                {
                    Console.WriteLine("*");
                }
            }
            Process();
        }
    }
