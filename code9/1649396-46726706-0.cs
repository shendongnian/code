     public static void Main(string[] args)
        {
            Console.WriteLine("Enter the number: ");
            string input = Console.ReadLine();
            int num;
            //  Console.WriteLine();
            if (Int32.TryParse(input, out num))
            {
                int i;
                for (i = 0; i <= 10; i++)
                {
                    int result = num * i;
                    Console.WriteLine("{0}*{1}={2}", num, i, result);
                }
            }
            else
            {
                //not an integer
                Console.WriteLine("not an integer");
            }
            Console.ReadLine();
        }
