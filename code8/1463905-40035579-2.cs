    private static void Number()
        {
            Console.Write("Type it in a number: ");
            int result;
            if (int.TryParse(Console.ReadLine(), out result))
            {
                 // user input a valid integer
                 // result varaible have the input integer
                 Console.Write("Hi");
            }
            else
            {
               // user input none integer
               Console.WriteLine("Please type a number!");
            }
            Console.ReadLine();
        }
