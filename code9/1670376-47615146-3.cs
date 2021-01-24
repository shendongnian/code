        class Program
    {
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
            for (int i = 1; i <= num; i++)
            {
                if ((i % 2 == 0) && i == 2)
                {
                    Console.WriteLine(string.Empty.PadLeft(num, '*'));
                }
                else
                {
                    Console.WriteLine("  *  ");
                }
            }
            Process();
        }
    }
