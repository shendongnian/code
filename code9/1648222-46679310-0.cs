     static void Main(string[] args)
        {
            Console.Write("PLEASE ENTER YOUR FIRST AND LAST NAME: ");
            string Name = Console.ReadLine();
            Console.Write("Enter the number of times you wish for me to repeat your name");
            var input = Console.ReadLine();
            int number = -1;
            while (!int.TryParse(input, out number)) {
                Console.WriteLine("Incorrect Value");
                Console.Write("Enter the number of times you wish for me to repeat your name");
                input = Console.ReadLine();
            }
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine("" + Name);
                if (i == 9)
                {
                    Console.WriteLine("End Program");
                    break;
                }
           }
            Console.ReadKey();
        }
