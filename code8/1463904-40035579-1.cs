    private static void Number()
        {
            Console.Write("Type it in a number: ");
            int num;
            if (int.TryParse(Console.ReadLine(), out num))
            {
                 // user input a valid integer
                 // num varaible have the input integer
                 Console.Write("Hi");
            }
            else
            {
               // user input none integer
               Console.WriteLine("Please type a number!");
            }
            Console.ReadLine();
        }
